using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
namespace xadrez
{
    class Torre: Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
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
            while(tab.posicaoValida(pos) && PodeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //Baixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Direita
            pos.DefinirValores(posicao.Linha , posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Esquerda
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {

                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }

    }
}
