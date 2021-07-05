using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro Tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private  HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;

        public PartidaDeXadrez()
        {
            this.Tab = new Tabuleiro(8,8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            Terminada = false;
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            
            Peca p = Tab.retirarPeca(origem);
            p.IncrementarMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                _capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            MudaJogador();
        }


        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(Tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (Tab.peca(pos).cor != jogadorAtual)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!Tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça de origem");
            }

        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino inválida");
            }
        }







        private void MudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }

        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in _capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }


        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in _capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }



        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            _pecas.Add(peca);
        }


        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));

            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));


        }
    }
}
