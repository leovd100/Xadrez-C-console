﻿using System;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Coluna; j++)
                {

                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        ImprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }


        public static void ImprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine().ToLower();
            char coluna = s[0];
            int linha = int.Parse(s[1].ToString());
            return new PosicaoXadrez(coluna, linha);
        }
    }
}

