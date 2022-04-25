using System;
using System.Collections.Generic;
using System.Threading;

namespace Exercicio1VendasEComissao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int numVendas = 0, numeroDeVendas = 1;
                bool test = false;
                List<Produto> produtos = ProdutoRepositorio.InicializarProdutos();
                List<Vendedor> vendedores = VendedorRepositorio.VendedorIncializaçao();
                List<Venda> vendas = new List<Venda>();
                int estoqueTotal = Produto.EstoqueTotal(produtos);

                while (!test)
                {
                    Console.WriteLine("----- Olá Bem Vindo a Loja Cast -----");
                    Console.WriteLine("Nós possuimos {0} produtos em estoque." +
                        "\nSó é permitida a venda de um produto por vez", estoqueTotal);
                    Console.Write("Digite a quantidade de vendas a ser realizada: ");
                    numVendas = int.Parse(Console.ReadLine());

                    if (numVendas <= estoqueTotal)
                    {
                        test = true;
                    }
                    else
                    {
                        Console.WriteLine("Desculpa, mas o número excede a quantidade de produtos do nosso estoque" +
                            "\nPor favor, digite outro número. Nós temos {0} produtos em estoque", estoqueTotal);
                        Thread.Sleep(2500);
                        Console.Clear();
                    }
                }

                while (numeroDeVendas <= numVendas)
                {
                    Console.WriteLine("\nLista de Produtos em Estoque");
                    foreach(Produto produto in produtos)
                    {
                        Console.WriteLine(produto);
                    }
                    Console.WriteLine("\nVamos realizar a venda #{0}! ", numeroDeVendas);
                    Console.Write("\nDigite o Id do vendedor: ");
                    int idVendedor = int.Parse(Console.ReadLine());
                    Vendedor vendedorVenda = Vendedor.EncontrarVendedor(vendedores, idVendedor);
                    if (vendedorVenda != null)
                    {
                        Console.WriteLine("Vendedor: " + vendedorVenda.Nome);
                        Console.Write("\nDigite o id do produto: ");
                        int idProduto = int.Parse(Console.ReadLine());
                        Produto produtoVenda = Produto.EncontrarProduto(produtos, idProduto);
                        if (produtoVenda != null)
                        {
                            Console.WriteLine("\nProduto: " + produtoVenda.Nome + " - Estoque " + produtoVenda.Estoque + " unidades");
                            Console.WriteLine("\nSó pode ser efetuada a compra de uma unidade por vez ");
                            int qtdProdutos = 1;
                            if (qtdProdutos <= produtoVenda.Estoque)
                            {
                                double valorTotal = produtoVenda.Valor * qtdProdutos;

                                Venda venda = new Venda(numeroDeVendas, vendedorVenda, produtoVenda, qtdProdutos, valorTotal);
                                venda.RealizarVenda(vendedorVenda, produtoVenda, qtdProdutos, valorTotal);
                                vendas.Add(venda);
                                numeroDeVendas++;
                            }
                            else
                            {
                                Console.WriteLine("\nNão possuimos essa quantidade em estoque");
                            }

                        }
                        else
                        {
                            Console.WriteLine("\nProduto Não Encontrado");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nVendedor não encontrado!");
                    }
                    Console.WriteLine("\nQualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }

                foreach (Venda venda1 in vendas)
                {
                    Console.WriteLine(venda1);
                }
              
                foreach (Vendedor vend in vendedores)
                {
                    Console.WriteLine(vend);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
