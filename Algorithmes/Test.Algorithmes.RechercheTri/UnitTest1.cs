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
        [Theory]
        [InlineData("3", false)]
        public void RechercheDansFichierOrArray_GetLastXRows(string input, bool b)
        {
            //Arrange
            var consoleMock = new Mock<IConsole>();
            consoleMock.SetupSequence(c => c.ReadLine())
                       .Returns(input); // Simuler que l'utilisateur entre "5"
            consoleMock.SetupSequence(c => c.ReadKey())
                       .Returns('n'); // Simuler que l'utilisateur entre "n"

            var recherche = new RechercheDansFichierOrArray(consoleMock.Object);
            //Act
            bool resultat = recherche.GetLastXRows(3, @"C:\Users\WilliamNanfack\Downloads\textlorem.txt");
            //Assert
            Assert.Equal(b, resultat);

        }
        /// <summary>
        /// string[] arrA = ["a", "e", "e", "e", "b"];
        /// string[] arrB = ["b", "b", "c", "e", "e", "g"];
        /// </summary>
        /// <param name="input"></param>
        /// <param name="resultatAttendu"></param>
        [Theory]
        [InlineData('o', @"[b, e, b, e]")]
        [InlineData('n', @"[a, c, g]")]
        public void RechercheDansFichierOrArray_GetElementDistinct(char input, string resultatAttendu)
        {
            //Arrange
            var consoleMock = new Mock<IConsole>();
            consoleMock.SetupSequence(c => c.ReadKey())
                       .Returns(input); // Simuler que l'utilisateur entre "n"

            var recherche = new RechercheDansFichierOrArray(consoleMock.Object);
            //Act
            var resultat = recherche.GetElementDistinct(false);
            //Assert
            Assert.Equal(resultatAttendu, resultat);

        }
    }
}