using System;
using tabuleiro;
using xadrez;
namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turo: " + partida.turno);
                        Console.WriteLine("Aguardando a jogada " + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Digite a origem: ");

                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);
                        bool[,] posicoesPossiveis = partida.Tab.peca(origem).MovimentosPossiveis();

                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);


                        Console.Write("Digite o destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);
                        partida.RealizaJogada(origem, destino);
                    }catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
