using System;
using System.Collections.Generic;
using System.Globalization;


namespace Exercicio1VendasEComissao
{
    internal class Produto
    {
        public int Codigo { get; }
        public string Nome { get; set; }
        public double Valor { get; private set; }
        public int Estoque { get; private set; }
        public int EstoqueMin { get;private set; }
        public int EstoqueMax { get; private set; }

        public Produto(int codigo, string nome, double valor, int estoque, int estoqueMin, int estoqueMax)
        {
            Codigo = codigo;
            Nome = nome;
            Valor = valor;
            Estoque = estoque;
            EstoqueMin = estoqueMin;
            EstoqueMax = estoqueMax;
        }

        public override string ToString()
        {
            return "ID: "+ Codigo.ToString("000") + ", Produto: " + Nome + ", Valor: R$ " 
                + Valor.ToString("F2", CultureInfo.InvariantCulture) + ", Estoque: " + Estoque;
        }
        public static Produto EncontrarProduto(List<Produto> produto, int id)
        {
            return produto.Find(x => x.Codigo == id);
        }

        public void Venda(int qtd)
        {
            Estoque -= qtd;
        }

        public void Compra(int qtd)
        {
            Estoque += qtd;
        }
        public static int EstoqueTotal(List<Produto> produtos)
        {
            int estoqueTotal = 0;

            foreach (Produto prod in produtos)
            {
                estoqueTotal += prod.Estoque;
            }
            return estoqueTotal;
        }
        public void VerificarEstoque()
        {
            Console.WriteLine("\nO Estoque após a venda é de {0} Unidades", Estoque);
            if (Estoque <= EstoqueMin)
            {
                Console.WriteLine($"\nO Estoque do Produto precisa ser reabastecido! Quantidade mínima é: {EstoqueMin}");
            }
            else if (Estoque >= EstoqueMax)
            {
                Console.WriteLine($"\nO produto atingiu ou superou o estoque máximo de {EstoqueMax} unidades!");
            }
     
        }
    }

    class ProdutoRepositorio
    {
        public static List<Produto> InicializarProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            produtos.Add(new Produto(234, "RTX3070 ASUS", 6000.00, 10, 10, 100));
            produtos.Add(new Produto(124, "RYZEN 5 5600x", 1100.00, 20, 15, 200));
            produtos.Add(new Produto(543, "MEMÓRIA RAM 8GB DDR4", 235.00, 17, 15, 100));
            produtos.Add(new Produto(965, "FONTE XPG 500w", 220.00, 14, 10, 100));
            produtos.Add(new Produto(003, "GABINETE CORSAIR", 230.00, 12, 10, 100));
            produtos.Add(new Produto(043, "SSD NVME 1TB XPG", 400.00, 13, 10, 100));


            return produtos;
        }
    }
}
