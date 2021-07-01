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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(5, 5));
                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(3, 2));


                Tela.ImprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
