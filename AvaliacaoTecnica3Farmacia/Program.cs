using System;
using System.Collections.Generic;

namespace AvaliacaoTecnica3Farmacia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Remedio> remedios = RemedioRepositorio.RemedioInicializar();
                int opcao = 0;
                do
                {
                    MenuInicial();

                    Console.Write("Digite sua opção: ");
                    opcao = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    ConfigMenuInicial(remedios, opcao);
                    Console.Write("\nQualquer tecla para continuar ");
                    Console.ReadKey();
                    Console.Clear();


                } while (opcao != 8);

               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void MenuInicial()
        {

            Console.WriteLine("----- Olá Bem Vindo a Farmácia Cast -----");
            Console.WriteLine("Esse é o nosso menu: ");
            Console.WriteLine(" 1 - Verificar se tem determinado remédio no estoque e sua posição" +
                "\n 2 - Para Listar os Remédios" +
                "\n 3 - Para adicionar novos remédios" +
                "\n 4 - Verificar o total de remédios" +
                "\n 5 - Ordenar lista por ordem alfabética " +
                "\n 6 - Realizar Busca por parte do Nome" +
                "\n 7 - Realizar a Exclusão de um Remédio" +
                "\n 8 - Para sair \n");


        }

        public static void ConfigMenuInicial(List<Remedio> remedios, int opcao)
        {
            Remedio config = new Remedio();
            switch (opcao)
            {
                case 1:
                    config.BuscarRemedio(remedios);
                    break;
                case 2:
                    config.ListarRemedios(remedios);
                    break;
                case 3:
                    config.AddRemedios(remedios);
                    break;
                case 4:
                    config.TotalDeRemedios(remedios);
                    break;
                case 5:
                    config.OrdenarLista(remedios);
                    break;
                case 6:
                    config.BuscaPorNomeParcial(remedios);
                    break;
                case 7:
                    config.RemoverRemedio(remedios);
                    break;
                case 8:
                    Console.WriteLine("\nObrigado por utilizar nosso sistema !!");
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }
    }
}