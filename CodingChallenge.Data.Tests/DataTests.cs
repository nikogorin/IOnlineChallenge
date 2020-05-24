using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        [SetCulture("es-AR")]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        [SetCulture("en-EN")]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        [SetCulture("pt-BR")]
        public void TestResumenListaVaciaEnPortugues()
        {
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        [SetCulture("es-ES")]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        [SetCulture("en-EN")]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        [SetCulture("en-EN")]
        public void TestResumenListaConMasTipos()
        {
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

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        [SetCulture("es-ES")]
        public void TestResumenListaConMasTiposEnCastellano()
        {
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

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        [SetCulture("pt-BR")]
        public void TestResumenListaConUnRectangulo()
        {
            var lista = new List<FormaGeometrica>
            {
                new Rectangulo(5, 2),
            };

            var resumen = FormaGeometrica.Imprimir(lista);

            Assert.AreEqual("<h1>Relatorio de Formas</h1>1 Retângulo | Area 10 | Perimetro 14 <br/>TOTAL:<br/>1 formas Perimetro 14 Area 10", resumen);
        }

        [TestCase]
        [SetCulture("pt-BR")]
        public void TestResumenListaConMasRectangulos()
        {
            var lista = new List<FormaGeometrica>
            {
                new Rectangulo(5, 2),
                new Rectangulo(6, 3),
            };

            var resumen = FormaGeometrica.Imprimir(lista);

            Assert.AreEqual("<h1>Relatorio de Formas</h1>2 Retângulos | Area 28 | Perimetro 32 <br/>TOTAL:<br/>2 formas Perimetro 32 Area 28", resumen);
        }

        [TestCase]
        [SetCulture("es-Es")]
        public void TestResumenListaConUnTrapecio()
        {
            var lista = new List<FormaGeometrica>
            {
                new Trapecio(2, 3, 4, 4, 2),
            };

            var resumen = FormaGeometrica.Imprimir(lista);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 5 | Perimetro 13 <br/>TOTAL:<br/>1 formas Perimetro 13 Area 5", resumen);
        }

        [TestCase]
        [SetCulture("en-EN")]
        public void TestValidacionRectangulo()
        {
            try
            {
                var lista = new List<FormaGeometrica>
                {
                    new Rectangulo(5, 5)
                };

            }
            catch (Exception ex)
            {
                Assert.AreEqual("The figure values ​​do not correspond to the figure you want to create.", ex.Message);
            }
        }

    }
}
