using Microsoft.VisualStudio.TestTools.UnitTesting;
using way2.Dominio.Modelo.Entidades;

namespace way2.Dominio.Modelo.Tests.Entidades.Testes
{
    [TestClass]
    public class PalavraTest
    {
        private readonly Palavra palavraComparadaZero;
        private readonly Palavra palavraComparadaUm;
        private readonly Palavra palavraComparadaDois;
        private readonly Palavra palavraComparadaTres;
        private readonly Palavra palavraComparadaQuatro;

        public PalavraTest()
        {
            palavraComparadaZero = new Palavra(1, "Carro");
            palavraComparadaUm = new Palavra(1, "Carro");
            palavraComparadaDois = new Palavra(2, "Zebra");
            palavraComparadaTres = new Palavra(3, "Abelha");
            palavraComparadaQuatro = new Palavra(4, "Carros");
        }

        [TestMethod]
        public void CompararPalavrasIguaisComSucesso()
        {
            var retorno = palavraComparadaZero.Comparar(palavraComparadaUm);

            Assert.AreEqual(retorno, 0);
        }

        [TestMethod]
        public void CompararPalavraDePesquisaEmPosicaoLexicoMenorQueAPalavraComparadaIniciandoComLetrasDiferentes()
        {
            var retorno = palavraComparadaZero.Comparar(palavraComparadaDois);

            Assert.IsTrue(retorno < 0);
        }

        [TestMethod]
        public void CompararPalavraDePesquisaEmPosicaoLexicoMaiorQueAPalavraComparadaIniciandoComLetrasDiferentes()
        {
            var retorno = palavraComparadaZero.Comparar(palavraComparadaTres);

            Assert.IsTrue(retorno > 0);
        }

        [TestMethod]
        public void CompararPalavraDePesquisaQueSeEncontraNoSingularQuantoAPalavraComparadaEstaNoPlural()
        {
            var retorno = palavraComparadaZero.Comparar(palavraComparadaQuatro);

            Assert.IsTrue(retorno < 0);
        }

        [TestMethod]
        public void CompararPalavraDePesquisaQueSeEncontraNoPluralQuantoAPalavraComparadaEstaNoSingular()
        {
            var retorno = palavraComparadaQuatro.Comparar(palavraComparadaZero);

            Assert.IsTrue(retorno > 0);
        }
    }
}
