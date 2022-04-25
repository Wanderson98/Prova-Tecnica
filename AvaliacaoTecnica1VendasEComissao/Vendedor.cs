using System;
using System.Collections.Generic;
using System.Globalization;


namespace Exercicio1VendasEComissao
{
    internal class Vendedor
    {

        public int IdVendedor { get;}
        public string Nome { get; private set; }
        public int QuantidadeVendas { get; set; }
        public double ValorTotalVendas { get; set; }


        public Vendedor(int idVendedor, string nome)
        {
            IdVendedor = idVendedor;
            Nome = nome;
        }

        public double Comissao()
        {
           
            if(QuantidadeVendas < 6)
            {
                return ValorTotalVendas * 0.0004;
            }
            else if (QuantidadeVendas < 11)
            {
                return ValorTotalVendas * 0.013;
            }
            else if (QuantidadeVendas < 16)
            {
                return ValorTotalVendas * 0.3;
            }
            else
            {
                return ValorTotalVendas * 0.5;
            }


        }

        public override string ToString()
        {
            return " Vendedor: " + Nome + ", Total de Vendas: R$ " + ValorTotalVendas.ToString("F2", CultureInfo.InvariantCulture) 
                + ", Comissao: R$ " + Comissao().ToString("F2", CultureInfo.InvariantCulture); 
        }

        public static Vendedor EncontrarVendedor(List<Vendedor> vendedors, int id)
        {
            return vendedors.Find(x => x.IdVendedor == id);
        }
    }

    class VendedorRepositorio
    {
        public static List<Vendedor> VendedorIncializaçao()
        {
            List<Vendedor> list = new List<Vendedor>();

            list.Add(new Vendedor(001, "Anderson"));
            list.Add(new Vendedor(002, "Joao Pedro"));
            list.Add(new Vendedor(003, "Francisca"));
            list.Add(new Vendedor(004, "Maria Joana"));

            return list;
        }
    }
}
