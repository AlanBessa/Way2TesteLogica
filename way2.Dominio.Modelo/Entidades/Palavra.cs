using System;
using way2.Infra.Commons.Helpers;

namespace way2.Dominio.Modelo.Entidades
{
    public class Palavra
    {
        private readonly ExpressaoRegular _expressaoRegular;

        public Palavra()
        {
            _expressaoRegular = new ExpressaoRegular();
        }

        public Palavra(int indicie, string nome) : this()
        {
            Indicie = indicie;
            Nome = nome;
        }

        public int Indicie { get; set; }

        public string Nome { get; set; }

        public int Comparar(Palavra palavra)
        {
            var palavraPesquisada = _expressaoRegular.RemoverAcentos(Nome.ToUpper()).ToCharArray();
            var palavraObtida = _expressaoRegular.RemoverAcentos(palavra.Nome.ToUpper()).ToCharArray();
            
            var ehIgual = true;
            int valorRetorno = 0;

            for (int i = 0; i < palavraPesquisada.Length; i++)
            {
                try
                {
                    valorRetorno = palavraPesquisada[i].CompareTo(palavraObtida[i]);

                    if (valorRetorno != 0)
                    {
                        ehIgual = false;
                        break;
                    }
                }
                catch (Exception)
                {
                    return 1;
                }
            }

            if (ehIgual && palavraPesquisada.Length < palavraObtida.Length) { valorRetorno = -1; }

            return valorRetorno;
        }
    }
}
