using System;
using System.Globalization;

namespace Exercicio1VendasEComissao
{
    internal class Venda
    {
        public int IdVenda { get; }
        public Vendedor Vendedor { get; set; }
        public Produto Produto { get; set; }
        public double ValorTotal { get; set; }
        public int Quantidade { get; set; }

        public Venda(int idVenda, Vendedor vendedor, Produto produto, int quantidade, double valorTotal)
        {
            IdVenda = idVenda;
            Vendedor = vendedor;
            Produto = produto;
            Quantidade = quantidade;
            ValorTotal = valorTotal;
        }
        public void RealizarVenda(Vendedor vendedor, Produto produto, int qtd, double valorTotal)
        {
            Console.WriteLine("\n Venda Realizada: " +
                "\n Vendedor: " + vendedor.Nome +
                "\n Produto: " + produto.Nome +
                "\n Quantidade: " + qtd +
                "\n Valor Total: R$ " + valorTotal.ToString("F2", CultureInfo.InvariantCulture )
                );

                produto.Venda(qtd);
                vendedor.QuantidadeVendas++;
                vendedor.ValorTotalVendas += valorTotal;
                produto.VerificarEstoque();
                
        }

        public override string ToString()
        {
            return "Venda ID: " + IdVenda +
                "\n Vendedor: " + Vendedor.Nome +
                "\n Produto: " + Produto.Nome +
                "\n Quantidade: " + Quantidade +
                "\n Valor total: R$ " + ValorTotal.ToString("F2", CultureInfo.InvariantCulture)
                + "\n";
        }
    }
}
