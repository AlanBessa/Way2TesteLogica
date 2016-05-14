using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using way2.Dominio.Modelo.Entidades;

namespace way2.ScreenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Entre com a palavra pesquisada ou escreva exit:");
                    var linha = Console.ReadLine(); 
                    if (linha == "exit")
                    {
                        break;
                    }

                    Console.Write("Pesquisando...");

                    var buscaRealizada = new Busca(linha);

                    buscaRealizada.Pesquisar();

                    var mensagemDeRetorno = string.Empty;

                    if(buscaRealizada.PalavraPesquisada.Indicie == -1)
                    {
                        mensagemDeRetorno = string.Format("A palavra {0} não se encontra no dicionario pesquisado. Para obter esta resposta {1} gatinhos foram sacrificados. Pobre gatinhos...", 
                                                          buscaRealizada.PalavraPesquisada.Nome,
                                                          buscaRealizada.NumeroDeGatinhosMortos);
                    }
                    else
                    {
                        mensagemDeRetorno = string.Format("A palavra {0} se encontra no indicie {1} do dicionario pesquisado. Para obter esta resposta {2} gatinhos foram sacrificados. Pobre gatinhos...",
                                                          buscaRealizada.PalavraPesquisada.Nome,
                                                          buscaRealizada.PalavraPesquisada.Indicie,
                                                          buscaRealizada.NumeroDeGatinhosMortos);
                    }
                    
                    Console.WriteLine(mensagemDeRetorno);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro na execução da aplicação. Status do erro: " + ex.Message);
                }
            }
        }
    }
}
