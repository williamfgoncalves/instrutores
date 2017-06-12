namespace NGames.Infrastruture.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NGames.Infrastruture.Context.NGamesDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NGames.Infrastruture.Context.NGamesDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var perfilOperador = new Domain.Entities.Permissao("Operador");
            if (!context.Permissoes.Where(p => p.Nome == "Operador").Any())
                context.Permissoes.Add(perfilOperador);

            var perfilGerente = new Domain.Entities.Permissao("Gerente");
            if (!context.Permissoes.Where(p => p.Nome == "Gerente").Any())
                context.Permissoes.Add(perfilGerente);

            var usuarioOperador = new Domain.Entities.Usuario("Usuario Operador", "operador@cwi.com.br", "123456");
            usuarioOperador.AtribuirPermisao(perfilOperador);
            if (!context.Usuarios.Where(p => p.Nome == "Usuario Operador").Any())
                context.Usuarios.Add(usuarioOperador);

            var usuarioGerente = new Domain.Entities.Usuario("Usuario Gerente", "gerente@cwi.com.br", "123456");
            usuarioGerente.AtribuirPermisao(perfilGerente);
            if (!context.Usuarios.Where(p => p.Nome == "Usuario Gerente").Any())
                context.Usuarios.Add(usuarioGerente);

            var produtoPS3 = new Domain.Entities.Produto("PS3", 100, 10);
            if (!context.Produtos.Where(p => p.Nome == "PS3").Any())
                context.Produtos.Add(produtoPS3);

            var produtoNintendo = new Domain.Entities.Produto("Nintendo", 100, 10);
            if (!context.Produtos.Where(p => p.Nome == "Nintendo").Any())
                context.Produtos.Add(produtoNintendo);

            var produtoXBox = new Domain.Entities.Produto("XBox", 100, 10);
            if (!context.Produtos.Where(p => p.Nome == "XBox").Any())
                context.Produtos.Add(produtoXBox);

            var produtoAtari = new Domain.Entities.Produto("Atari", 100, 10);
            if (!context.Produtos.Where(p => p.Nome == "Atari").Any())
                context.Produtos.Add(produtoAtari);

            var opcionalJogo = new Domain.Entities.Opcional("Jogo", 10, 15);
            if (!context.Opcionais.Where(p => p.Nome == "Jogo").Any())
                context.Opcionais.Add(opcionalJogo);

            var opcionalMC = new Domain.Entities.Opcional("Memory Card", 10, 15);
            if (!context.Opcionais.Where(p => p.Nome == "Memory Card").Any())
                context.Opcionais.Add(opcionalMC);

            var opcionalControle = new Domain.Entities.Opcional("Controle", 10, 15);
            if (!context.Opcionais.Where(p => p.Nome == "Controle").Any())
                context.Opcionais.Add(opcionalControle);

            var pacoteDiario = new Domain.Entities.Pacote("Diário: 1 Jogo + 1 controle", 5, 15);
            var pacoteFinde = new Domain.Entities.Pacote("Finde: 2 Jogos + 1 controle", 7, 15);
            var pacoteSemana = new Domain.Entities.Pacote("Semana: 5 Jogo + 1 controle", 10, 15);

            context.SaveChanges();
        }
    }
}
