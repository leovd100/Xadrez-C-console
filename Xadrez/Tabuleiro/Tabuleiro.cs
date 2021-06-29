using System;
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


        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public bool existeUmaPeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }


        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existeUmaPeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição.");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }



        public bool posicaoValida(Posicao pos)
        {
            if(pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna > Coluna)
            {
                return false;
            }
            return true;
        }


        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }

    }
}
