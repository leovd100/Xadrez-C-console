using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Coluna];
            Posicao pos = new Posicao(0, 0);

            //Cima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            if(tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Nordeste
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna+1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Sudeste
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna -1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // baixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna );
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // SuldoEste
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna -1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Esquerda
            pos.DefinirValores(posicao.Linha , posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Noroeste
            pos.DefinirValores(posicao.Linha-1, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }

    }
}
