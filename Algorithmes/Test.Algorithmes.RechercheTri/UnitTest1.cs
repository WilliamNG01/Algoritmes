using Algorithmes.RechercheTri;
using Moq;
using System;

namespace Test.Algorithmes.RechercheTri
{
    public class UnitTest1
    {
        //[Fact]
        [Theory]
        [InlineData("0", "0")]// Cas de 0
        [InlineData("42", "2A")]// Cas de 0
        [InlineData("255", "FF")]// Cas de 255
        [InlineData("256", "100")]// Cas de 255
        [InlineData("123456", "1E240")]// Cas de grand nombre
        [InlineData("-255", "FFFFFF01")]// Cas de nombre négatif
        public void RechercheDansFichierOrArray_DecimalToHexadecimal(string input, string resultatAttendu)
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            consoleMock.SetupSequence(c => c.ReadLine())
                       .Returns(input); // Simuler que l'utilisateur entre "5"

            var recherche = new RechercheDansFichierOrArray(consoleMock.Object);

            // Act
            string resultat = recherche.DecimalToHexadecimal();

            // Assert
            Assert.Equal(resultatAttendu, resultat);

        }
    }
}