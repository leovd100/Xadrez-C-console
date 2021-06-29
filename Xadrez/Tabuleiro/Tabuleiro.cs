﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Coluna { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Coluna = colunas;
            pecas = new Peca[linhas, colunas];
        }

    }
}