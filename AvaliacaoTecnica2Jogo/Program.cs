using System;

namespace AvaliacaoTecnica2Jogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tentativasGame = 1;
            int vezesProximas = 0;
            int tentativas = 0;
            int gamePrincipal = 0;
            bool respostaCerta = false;
            Console.WriteLine("--- Bem Vindo a Cast Games -------");
            int primerapegadinha = new Random().Next(1, 5);
            InicioGame();
            Console.Write("Digite o número entre 1 e 5: ");
            int primeiraResposta = int.Parse(Console.ReadLine());

            if (primeiraResposta == primerapegadinha)
            {
                respostaCerta = false;
                tentativas = primeiraResposta * 5;
                Console.WriteLine($"\nParabéns, Você acertou e terá direito a {tentativas} tentativas");
                gamePrincipal = new Random().Next(1, 10);
                Console.WriteLine("\nAgora você terá que acertar um número entre 1 e 10: ");
                while (!respostaCerta && tentativasGame <= tentativas)
                {

                    Console.Write("Digite seu número: ");
                    int tentGame = int.Parse(Console.ReadLine());
                    vezesProximas += NumeroProximo(tentGame, gamePrincipal);
                    if (tentGame == gamePrincipal)
                    {
                        Console.WriteLine("\nParabéns, você acertou em {0} tentativas", tentativasGame);
                        Console.WriteLine($"Vocé ficou próximo por 1 número {vezesProximas} vezes");
                        respostaCerta = true;
                    }
                    else
                    {
                        Console.WriteLine("\nNão foi dessa vez! Tente de novo trapalhão");
                        tentativasGame++;
                    }

                }
            }
            else
            {
                respostaCerta = false;
                tentativas = 10 / primeiraResposta + 1;
                Console.WriteLine($"\nJá começou mal HAHAHA! Você terá {tentativas} tentativas");
                Console.WriteLine("\nAgora você terá que acertar um número entre 1 e 20 e em toda rodada esse número muda! ");
                while (!respostaCerta && tentativasGame <= tentativas)
                {
                    gamePrincipal = new Random().Next(1, 20);
                    Console.Write("Digite seu número: ");
                    int tentGame = int.Parse(Console.ReadLine());
                    if (tentGame == gamePrincipal)
                    {
                        Console.WriteLine("\nParabéns, você pode apostar na megasena, você acertou no modo hard em {0} tentativas", tentativasGame);
                        Console.WriteLine($"Vocé ficou próximo por 1 número {vezesProximas} vezes");

                    }
                    else
                    {
                        Console.WriteLine("\nNão foi dessa vez, mas não é surpresa né! Tente de novo ou só desista e vá pra casa !");
                        tentativasGame++;
                    }

                }
            }
            Console.WriteLine();
            if (!respostaCerta)
            {
                Console.WriteLine($"Você teve {tentativas} tentativas e não acertou nenhuma vacilão");
                Console.WriteLine($"Vocé ficou próximo por 1 número {vezesProximas} vezes");
            }


        }

        public static void InicioGame()
        {
            Console.WriteLine("A primeira parte é escolher um número entre 1 e 5." +
                "\nSe Você acertar, terá o número, que escolheu multiplicado por 5, como número de tentativas," +
                "\nE o número a ser advinhado permancerá o mesmo durante toda o jogo!" +
                "\nSe errar você terá como tentativas, 10 dividido pelo número escolhido, mais uma tentativa de bônus" +
                "\nE em toda rodada o número será mudado. Boa sorte!");
        }

        public static int NumeroProximo(int tentativa, int respostaGame)
        {
            if (tentativa - respostaGame == 1 || tentativa - respostaGame == -1)
            {
                return 1;
            }
            return 0;
        }
    }
}
