using Alura.Adopet.Console.Utils.Extensions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Alura.Adopet.Console.Tests
{

    public class RetornaPetStringTests
    {
        [Fact]
        [Trait("Pet", "Valido")]
        public void DeveRetornarPet_CasoStringValida()
        {
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            Pet pet = linha.RetornaPetString();

            Assert.NotNull(pet);
        }

        [Fact]
        [Trait("Pet", "Invalido")]
        public void DeveRetornarExcecao_CasoStringForInvalida()
        {
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1;2";

            Assert.Throws<Exception>(() => linha.RetornaPetString());
        }

        [Fact]
        [Trait("Pet", "Null")]
        [Trait("Pet", "Vazio")]
        public void DeveRetornarExcecao_CasoStringVaziaOuNula()
        {
            string str = "";

            Assert.Throws<Exception>(() => str.RetornaPetString());
        }
        [Fact]
        [Trait("Pet", "Guid")]
        public void DeveRetornarExcecao_GuidInvalido()
        {
            string linha = "456b24f4-19e2-4423-84;Lima Limão;1";

            Assert.Throws<FormatException>(() => linha.RetornaPetString());
        }
        [Fact]
        [Trait("Pet", "TipoPet")]
        public void DeveRetornarExcecao_CasoTipoPetInvalido()
        {
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;a";

            Assert.Throws<FormatException>(() => linha.RetornaPetString());
        }
    }
}