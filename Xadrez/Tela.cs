using System;
using tabuleiro;

namespace Xadrez
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Coluna; j++)
                {
      
                   Console.Write(tab.peca(i, j) == null ? "- " : tab.peca(i, j) + " ");
                   
                }
                Console.WriteLine();
            }
        }
    }
}

