using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTecnica3Farmacia
{
    internal class Remedio : IComparable
    {
        public string Nome { get; set; }

        public Remedio(string nome)
        {
            Nome = nome;
        }
        public Remedio()
        {
        }

        public void ListarRemedios(List<Remedio> remedios)
        {
            int i = 0;
            foreach (Remedio item in remedios)
            {
                Console.WriteLine(i + " - " + item);
                i++;
            }
        }
        public void TotalDeRemedios(List<Remedio> remedios)
        {
            Console.WriteLine("Exitem {0} remédios no estoque", remedios.Count);
        }
        public void AddRemedios(List<Remedio> remedios)
        {
            Console.Write("Digite o nome do remédio a ser adicionado: ");
            string remedio = Console.ReadLine().ToUpper();
            remedios.Add(new Remedio(remedio));
            ListarRemedios(remedios);
        }
        public void RemoverRemedio(List<Remedio> remedios)
        {   
            int antesExclusao = remedios.Count;
            int dpsExclusao = remedios.Count;
            Console.Write("Digite o nome do remédio a ser excluido: ");
            string remedio = Console.ReadLine().ToUpper();
            int posicao = remedios.FindIndex(x => x.Nome == remedio);
            if(posicao >= 0)
            {
                remedios.RemoveAt(posicao);
                dpsExclusao = remedios.Count;
            }

            if(antesExclusao == dpsExclusao)
            {
                Console.WriteLine("\nNão foi encontrado esse medicamento para excluir");
            }
            else if(antesExclusao > dpsExclusao)
            {
                Console.WriteLine("\nExclusão feita com sucesso!");
                ListarRemedios(remedios);
            }
           
        }

        public void BuscarRemedio(List<Remedio> remedios)
        {
            Console.Write("Digite o nome do remédio: ");
            string remedio = Console.ReadLine().ToUpper();

            int posicao = remedios.FindIndex(x => x.Nome == remedio);

            if(posicao < 0)
            {
                Console.WriteLine("Não tem esse remédio na lista");
            }
            else
            {
                Console.WriteLine($"Temos esse remédio na lista e ele está na posição {posicao}");
            }
        }
        public void OrdenarLista(List<Remedio> remedios)
        {
            remedios.Sort();
            int i = 0;
            foreach (Remedio item in remedios)
            {
                Console.WriteLine(i + " - " + item);
                i++;
            }
        }
        public void BuscaPorNomeParcial(List<Remedio> remedios)
        {
            Console.Write("Digite a parte do nome que você deseja consultar: ");
            string parteDoNome = Console.ReadLine().ToUpper();
            List<Remedio> lista = remedios.FindAll(x => x.Nome.Contains(parteDoNome));
            if(lista != null)
            {
                Console.WriteLine($"\nRemedios Encontrados com '{parteDoNome}' \n");
                foreach (Remedio item in lista)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine($"Não foi encontrado nenhum remédio com '{parteDoNome}'");
            }
          
        }

        public override string ToString()
        {
            return Nome;
        }

        public int CompareTo(object obj)
        {
           if(!(obj is Remedio))
            {
                throw new ArgumentException("An error ocurred");
            }
            else
            {
                Remedio other = obj as Remedio;
                return Nome.CompareTo(other.Nome);
            }
        }
    }

    class RemedioRepositorio
    {
        public static List<Remedio> RemedioInicializar()
        {
            List<Remedio> list = new List<Remedio>();
            list.Add(new Remedio("Paracetamol".ToUpper()));
            list.Add(new Remedio("Dipirona".ToUpper()));
            list.Add(new Remedio("Nimesulida".ToUpper()));
            list.Add(new Remedio("Neosaldina".ToUpper()));
            list.Add(new Remedio("Diazepan".ToUpper()));
            list.Add(new Remedio("Buscopan".ToUpper()));


            return list;


        }
    }
}

