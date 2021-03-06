using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qntMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qntMovimentos = 0;
        } 

        public void IncrementarMovimentos()
        {
            qntMovimentos++;
        }

        public void DecrementarMovimentos()
        {
            qntMovimentos--;
        }


        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i< tab.linhas; i++)
            {
                for(int j = 0; j<tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha,pos.Coluna];
        }


        public abstract bool[,] MovimentosPossiveis();
       
    }
}
