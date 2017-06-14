/*
1) Liste os produtos (id e nome) que não tiveram nenhuma compra 
nos últimos quatro meses.
*/

CREATE VIEW vwProdutos_Sem_Compra AS
SELECT IDProduto, Nome
FROM   Produto
WHERE  IDProduto NOT IN (Select item.IDProduto
                         From   PedidoItem item
                          inner join Pedido ped on ped.IDPedido = item.IDPedido
                         Where  ped.DataPedido >= add_months(trunc(sysdate), -4)
                         );
------------------

/* 2) */
UPDATE Produto
SET    Situacao = 'I'
WHERE  IDProduto IN (Select IDProduto from vwProdutos_Sem_Compra);

UPDATE Produto
SET    Situacao = 'I'
WHERE  EXISTS (Select IDProduto 
               from vwProdutos_Sem_Compra vw
               where  Produto.IDProduto = vw.IDProduto)
 and Situacao = 'A';

-------------------------

/* 3) */
Select SUM(item.Quantidade) qtde
From   PedidoItem item 
  inner join Pedido ped on ped.IDPedido = item.IDPedido
Where  item.IDProduto  = :IDPRODUTO
and    ped.DataPedido >= trunc(sysdate, 'yyyy');

------------------------------------------------------------------------