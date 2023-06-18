using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Formas;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Globalization.Services;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private WindsorContainer Container;

        [SetUp]
        public void SetUp()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For(typeof(ILocalizationService)).ImplementedBy<LocalizationService>());
            Cuadrado cuadrado = new Cuadrado(2);
        }

        [TearDown]
        public void TearDownw()
        {
            Container.Dispose();
        }

        [TestCase]
        public void TestCrearCirculo()
        {
            //Arrange
            Circulo circulo = new Circulo(5);
            //Act
            //Assert
            Assert.IsNotNull(circulo);
        }

        [TestCase]
        public void TestCrearCuadrado()
        {
            //Arrange
            Cuadrado cuadrado = new Cuadrado(5);
            //Act
            //Assert
            Assert.IsNotNull(cuadrado);
        }

        [TestCase]
        public void TestCrearRectangulo()
        {
            //Arrange
            Rectangulo rectangulo = new Rectangulo(5,7);
            //Act
            //Assert
            Assert.IsNotNull(rectangulo);
        }

        [TestCase]
        public void TestCrearTrapecio()
        {
            //Arrange
            Trapecio trapecio = new Trapecio(7, 5, 4, 5);
            //Act
            //Assert
            Assert.IsNotNull(trapecio);
        }

        [TestCase(5,7)]
        public void TestBaseMayorTrapecio(decimal baseMayor, decimal baseMenor)
        {
            try
            {
                Trapecio trapecio = new Trapecio(baseMayor, baseMenor, 3, 4);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("La base mayor debe ser un valor numérico superior a la base menor", ex.Message);
            }
        }

        [TestCase(5, 0)]
        [TestCase(0, 5)]
        public void TestBaseCeroTrapecio(decimal baseMayor, decimal baseMenor)
        {
            try
            {
                Trapecio trapecio = new Trapecio(baseMayor, baseMenor, 5, 7);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Las bases deben tener distinto valor de cero", ex.Message);
            }
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnEspañol()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>();

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Español);

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                resumen);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>();

            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(formas,Idioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), Idioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            //Arr
            Cuadrado cuadrado = new Cuadrado(2);
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            formas.Add(cuadrado);
            //Act
            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Español);
            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Perímetro: 8 | Área: 4 |<br/>TOTAL:<br/>1 Forma |Perímetro: 8 | Área: 4 |", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            //Arrange
            Cuadrado cuadrado1 = new Cuadrado(2);
            Cuadrado cuadrado2 = new Cuadrado(3);
            Cuadrado cuadrado3 = new Cuadrado(4);
            Cuadrado cuadrado4 = new Cuadrado(5);
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            formas.Add(cuadrado1);
            formas.Add(cuadrado2);
            formas.Add(cuadrado3);
            formas.Add(cuadrado4);
            //Act
            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Ingles);
            //Assert
            Assert.AreEqual("<h1>Shapes Report</h1>4 Squares | Perimeter: 56 | Area: 54 |<br/>TOTAL:<br/>4 Shapes |Perimeter: 56 | Area: 54 |", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            //Arr
            Trapecio trapecio = new Trapecio(7,5,3,2);
            List<FormaGeometrica> formas = new List<FormaGeometrica>();
            formas.Add(trapecio);
            //Act
            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Español);
            //Assert
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Perímetro: 18 | Área: 35 |<br/>TOTAL:<br/>1 Forma |Perímetro: 18 | Área: 35 |", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            //Arrange
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(4),
                new Cuadrado(2),
                new Triangulo(9),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };
            //Act
            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Ingles);
            //Assert
            Assert.AreEqual(
                "<h1>Shapes Report</h1>2 Squares | Perimeter: 28 | Area: 29 |<br/>2 Circles | Perimeter: 36.13 | Area: 52.03 |<br/>3 Triangles | Perimeter: 51.6 | Area: 49.64 |<br/>TOTAL:<br/>7 Shapes |Perimeter: 115.73 | Area: 130.67 |",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            //Arrange
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(4),
                new Cuadrado(2),
                new Triangulo(9),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };
            //Act
            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Español);
            //Assert
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Perímetro: 28 | Área: 29 |<br/>2 Círculos | Perímetro: 36.13 | Área: 52.03 |<br/>3 Triángulos | Perímetro: 51.6 | Área: 49.64 |<br/>TOTAL:<br/>7 Formas |Perímetro: 115.73 | Área: 130.67 |",
                resumen);
        }
    }
}
