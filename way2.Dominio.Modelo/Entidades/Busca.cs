using System;
using way2.Infra.Commons.WebService;

namespace way2.Dominio.Modelo.Entidades
{
    public class Busca
    {
        private readonly Response _response;
        
        public Busca(string palavraPesquisada)
        {
            _response = new Response();

            PalavraPesquisada = new Palavra(-1, palavraPesquisada);
            PalavraDeMenorIndicie = new Palavra(0, string.Empty);
            PalavraDeMaiorIndicie = new Palavra(0, string.Empty);
        }

        public int NumeroDeGatinhosMortos { get; set; }

        public Palavra PalavraDeMaiorIndicie { get; set; }

        public Palavra PalavraDeMenorIndicie { get; set; }

        public Palavra PalavraPesquisada { get; set; }

        public void Pesquisar()
        {
            try
            {
                ObterLimiteMaximoDeBusca();

                var FoiEncontradaAPalavra = false;
                var posicaoPesquisada = PalavraDeMaiorIndicie.Indicie / 2;

                while (!FoiEncontradaAPalavra)
                {
                    var palavraObtida = new Palavra(posicaoPesquisada, _response.ObterResposta(posicaoPesquisada));

                    NumeroDeGatinhosMortos++;

                    if (string.IsNullOrEmpty(palavraObtida.Nome))
                    {
                        PalavraDeMaiorIndicie = palavraObtida;

                        posicaoPesquisada = CalcularProximaPosicaoASePesquisar();
                    }
                    else
                    {
                        var valorRetornado = PalavraPesquisada.Comparar(palavraObtida);
                        
                        if (valorRetornado == 0)
                        {
                            PalavraPesquisada = palavraObtida;
                            FoiEncontradaAPalavra = true;
                        }
                        else if (valorRetornado > 0)
                        {
                            if (PalavraDeMenorIndicie.Indicie == palavraObtida.Indicie)
                                break;

                            PalavraDeMenorIndicie = palavraObtida;

                            posicaoPesquisada = CalcularProximaPosicaoASePesquisar();
                        }
                        else if (valorRetornado < 0)
                        {
                            if (PalavraDeMaiorIndicie.Indicie == palavraObtida.Indicie)
                                break;

                            PalavraDeMaiorIndicie = palavraObtida;

                            posicaoPesquisada = CalcularProximaPosicaoASePesquisar();
                        }
                    }                    
                }                
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private void ObterLimiteMaximoDeBusca()
        {
            var retorno = _response.ObterResposta(PalavraDeMaiorIndicie.Indicie);
            
            while (retorno != null)
            {
                PalavraDeMaiorIndicie.Indicie = PalavraDeMaiorIndicie.Indicie + 10000;

                retorno = _response.ObterResposta(PalavraDeMaiorIndicie.Indicie);

                if (retorno != null && retorno.Contains("html")) throw new Exception("Webservice indisponivel no momento. Tente mais tarde. Um gatinho morreu por causa disso!:~(");

                NumeroDeGatinhosMortos++;
            }            
        }

        private int CalcularProximaPosicaoASePesquisar()
        {
            return ((PalavraDeMaiorIndicie.Indicie - PalavraDeMenorIndicie.Indicie) / 2) + PalavraDeMenorIndicie.Indicie;
        }
    }
}
