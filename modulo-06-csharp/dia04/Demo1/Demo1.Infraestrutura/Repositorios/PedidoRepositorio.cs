using Demo1.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Infraestrutura.Repositorios
{
    public class PedidoRepositorio : RepositorioBase, IPedidoRepositorio
    {
        public void Alterar(Pedido pedido)
        {
            using (var conexao = CriarConexao())
            {
                // Atualizar o nome do cliente
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = "UPDATE Pedido SET NomeCliente = @nomeCliente WHERE Id = @id";

                    comando.Parameters.AddWithValue("@nomeCliente", pedido.NomeCliente);
                    comando.Parameters.AddWithValue("@id", pedido.Id);

                    comando.ExecuteNonQuery();
                }

                foreach (var itemPedido in pedido.Itens)
                {
                    // se adicionou mais um item na cesta de pedidos
                    if (itemPedido.Id == 0)
                    {
                        CriarItemPedido(conexao, pedido, itemPedido);
                        BaixarEstoque(conexao, itemPedido);
                    }
                    else
                    {
                        // se atualizou o item da lista de pedidos
                        int diferencaEstoque = 0;
                        // Obtém a quantidade anterior de itens para calcular a diferença que precisa ser
                        // estornada
                        using (var comando = conexao.CreateCommand())
                        {
                            comando.CommandText = "SELECT Quantidade FROM ItemPedido WHERE Id = @id";
                            comando.Parameters.AddWithValue("@id", itemPedido.Id);
                            diferencaEstoque = (int)comando.ExecuteScalar();
                        }

                        using (var comando = conexao.CreateCommand())
                        {
                            comando.CommandText =
                                @"UPDATE ItemPedido SET PedidoId = @pedidoId, ProdutoId = @produtoId, Quantidade = @quantidade
                            WHERE Id = @id";

                            comando.Parameters.AddWithValue("@id", itemPedido.Id);
                            comando.Parameters.AddWithValue("@pedidoId", pedido.Id);
                            comando.Parameters.AddWithValue("@produtoId", itemPedido.ProdutoId);
                            comando.Parameters.AddWithValue("@quantidade", itemPedido.Quantidade);

                            comando.ExecuteNonQuery();
                        }

                        AtualizarEstoque(conexao, itemPedido, diferencaEstoque);
                    }

                    // apaga itens excluidos do pedido
                    // buscar os itens que estão no banco
                    // verifica se este item está na lsita de itens do pedido
                    // se não está, exclui e atualiza estoque
                    var itensPedidoExcluir = new List<ItemPedido>();
                    using (var comando = conexao.CreateCommand())
                    {
                        comando.CommandText = "SELECT Id, PedidoId, ProdutoId, Quantidade FROM ItemPedido WHERE PedidoId = @pedidoid";
                        comando.Parameters.AddWithValue("@pedidoid", pedido.Id);

                        using (var dataReader = comando.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var itemPedidoExcluir = LerItemPedido(dataReader);
                                if (!pedido.Itens.Where(item => item.Id == itemPedidoExcluir.Id).Any())
                                {
                                    itensPedidoExcluir.Add(itemPedidoExcluir);
                                }
                            }
                        }
                    }

                    foreach (var excluirItem in itensPedidoExcluir)
                    {
                        using (var comando = conexao.CreateCommand())
                        {
                            comando.CommandText = "DELETE ItemPedido WHERE Id = @id";
                            comando.Parameters.AddWithValue("@id", pedido.Id);
                            comando.ExecuteNonQuery();
                        }

                        IncrementarEstoque(conexao, excluirItem);
                    }
                }
            }
        }

        public void Criar(Pedido pedido)
        {
            using (var conexao = CriarConexao())
            {
                // BEGIN TRAN
                var transacao = conexao.BeginTransaction();

                try
                {
                    using (var comando = conexao.CreateCommand())
                    {
                        // informa a transação para o comando
                        comando.Transaction = transacao;

                        comando.CommandText =
                            @"INSERT INTO Pedido (NomeCliente) 
                        VALUES (@nomeCliente)";

                        comando.Parameters.AddWithValue("@nomeCliente", pedido.NomeCliente);

                        comando.ExecuteNonQuery();
                    }

                    using (var comando = conexao.CreateCommand())
                    {
                        comando.Transaction = transacao;
                        comando.CommandText = "SELECT CAST(@@IDENTITY AS INT)";
                        pedido.Id = (int)comando.ExecuteScalar();
                    }

                    foreach (var itemPedido in pedido.Itens)
                    {
                        CriarItemPedido(conexao, pedido, itemPedido, transacao);
                        BaixarEstoque(conexao, itemPedido, transacao);
                    }

                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
            }
        }

        public void Excluir(int id)
        {
            var pedido = Obter(id);

            using (var conexao = CriarConexao())
            {
                foreach (var item in pedido.Itens)
                {
                    IncrementarEstoque(conexao, item);
                }

                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = "DELETE ItemPedido WHERE PedidoId = @pedidoId";
                    comando.Parameters.AddWithValue("@pedidoId", id);
                    comando.ExecuteNonQuery();
                }

                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = "DELETE Pedido WHERE Id = @id";
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Pedido> Listar()
        {
            var pedidos = new List<Pedido>();

            using (var conexao = CriarConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = "SELECT Id, NomeCliente FROM Pedido";
                    using (var dataReader = comando.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            pedidos.Add(LerPedido(dataReader));
                        }
                    }
                }

                foreach (var pedido in pedidos)
                {
                    using (var comando = conexao.CreateCommand())
                    {
                        comando.CommandText =
                            "SELECT Id, PedidoId, ProdutoId, Quantidade FROM ItemPedido WHERE PedidoId = @pedidoId";

                        comando.Parameters.AddWithValue("@pedidoId", pedido.Id);

                        using (var dataReader = comando.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                pedido.Itens.Add(LerItemPedido(dataReader));
                            }
                        }
                    }
                }
            }

            return pedidos;
        }

        public Pedido Obter(int id)
        {
            Pedido pedido = null;

            using (var conexao = CriarConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = "SELECT Id, NomeCliente FROM Pedido WHERE Id = @id";
                    comando.Parameters.AddWithValue("@id", id);

                    using (var dataReader = comando.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            pedido = LerPedido(dataReader);
                        }
                    }
                }

                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText =
                        "SELECT Id, PedidoId, ProdutoId, Quantidade FROM ItemPedido WHERE PedidoId = @pedidoId";

                    comando.Parameters.AddWithValue("@pedidoId", pedido.Id);

                    using (var dataReader = comando.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            pedido.Itens.Add(LerItemPedido(dataReader));
                        }
                    }
                }
            }

            return pedido;
        }

        private void BaixarEstoque(SqlConnection conexao, ItemPedido item, SqlTransaction tran = null)
        {
            using (var comando = conexao.CreateCommand())
            {
                comando.Transaction = tran;
                comando.CommandText = "UPDATE PRODUTO SET Estoque = Estoque - @quantidade WHERE Id = @produtoId";
                comando.Parameters.AddWithValue("@produtoId", item.ProdutoId);
                comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
                comando.ExecuteNonQuery();
            }
        }

        private void IncrementarEstoque(SqlConnection conexao, ItemPedido item)
        {
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "UPDATE PRODUTO SET Estoque = Estoque + @quantidade WHERE Id = @produtoId";
                comando.Parameters.AddWithValue("@produtoId", item.ProdutoId);
                comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
                comando.ExecuteNonQuery();
            }
        }

        private void AtualizarEstoque(SqlConnection conexao, ItemPedido item, int diferenca)
        {
            using (var comando = conexao.CreateCommand())
            {
                comando.CommandText = "UPDATE Produto SET Estoque = Estoque - @quantidade WHERE Id = @produtoid";
                comando.Parameters.AddWithValue("@produtoId", item.ProdutoId);
                comando.Parameters.AddWithValue("@quantidade", item.Quantidade - diferenca);

                comando.ExecuteNonQuery();
            }
        }

        private void CriarItemPedido(SqlConnection conexao, Pedido pedido, ItemPedido itemPedido, SqlTransaction tran = null)
        {
            using (var comando = conexao.CreateCommand())
            {
                comando.Transaction = tran;

                comando.CommandText =
                    @"INSERT INTO ItemPedido (PedidoId, ProdutoId, Quantidade) 
                            VALUES (@pedidoId, @produtoId, @quantidade)";

                comando.Parameters.AddWithValue("@pedidoId", pedido.Id);
                comando.Parameters.AddWithValue("@produtoId", itemPedido.ProdutoId);
                comando.Parameters.AddWithValue("@quantidade", itemPedido.Quantidade);

                comando.ExecuteNonQuery();
            }

            using (var comando = conexao.CreateCommand())
            {
                comando.Transaction = tran;
                comando.CommandText = "SELECT CAST(@@IDENTITY AS INT)";
                itemPedido.Id = (int)comando.ExecuteScalar();
            }
        }

        private Pedido LerPedido(SqlDataReader dataReader)
        {
            return new Pedido()
            {
                Id = (int)dataReader["Id"],
                NomeCliente = (string)dataReader["NomeCliente"]
            };
        }

        private ItemPedido LerItemPedido(SqlDataReader dataReader)
        {
            return new ItemPedido()
            {
                Id = (int)dataReader["Id"],
                ProdutoId = (int)dataReader["ProdutoId"],
                Quantidade = (int)dataReader["Quantidade"]
            };
        }
    }
}

