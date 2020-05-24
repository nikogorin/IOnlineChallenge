/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Challenge.Language;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public static string Imprimir(List<FormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
                return GetString("empty_list");

            // Hay por lo menos una forma
            #region Calcular Cuadrados
            var listCuadrados = formas.Where(x => x.GetType().Name == "Cuadrado").ToList();
            var numeroCuadrados = listCuadrados.Count;
            var areaCuadrados = listCuadrados.Sum(x => x.CalcularArea());
            var perimetroCuadrados = listCuadrados.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Circulos
            var listCirculos = formas.Where(x => x.GetType().Name == "Circulo").ToList();
            var numeroCirculos = listCirculos.Count;
            var areaCirculos = listCirculos.Sum(x => x.CalcularArea());
            var perimetroCirculos = listCirculos.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Triangulos
            var listTriangulos = formas.Where(x => x.GetType().Name == "Triangulo").ToList();
            var numeroTriangulos = listTriangulos.Count;
            var areaTriangulos = listTriangulos.Sum(x => x.CalcularArea());
            var perimetroTriangulos = listTriangulos.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Rectangulo
            var listRectangulos = formas.Where(x => x.GetType().Name == "Rectangulo").ToList();
            var numeroRectangulos = listRectangulos.Count;
            var areaRectangulos = listRectangulos.Sum(x => x.CalcularArea());
            var perimetroRectangulos = listRectangulos.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Trapecio
            var listTrapecios = formas.Where(x => x.GetType().Name == "Trapecio").ToList();
            var numeroTrapecios = listTrapecios.Count;
            var areaTrapecios = listTrapecios.Sum(x => x.CalcularArea());
            var perimetroTrapecios = listTrapecios.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Texto Impresion
            // HEADER
            sb.Append(GetString("header"));
            //BODY
            var linea = GetString("body");//{0} {1} | Area {2} | Perimeter{3} <br/>
            if (numeroCuadrados > 0)
                sb.Append(string.Format(linea, numeroCuadrados, ResolveShapeName(numeroCuadrados, "shape_square", "shape_squares"), areaCuadrados.ToString("#.##"), perimetroCuadrados.ToString("#.##")));
            if (numeroCirculos > 0)
                sb.Append(string.Format(linea, numeroCirculos, ResolveShapeName(numeroCirculos, "shape_circle", "shape_circles"), areaCirculos.ToString("#.##"), perimetroCirculos.ToString("#.##")));
            if (numeroTriangulos > 0)
                sb.Append(string.Format(linea, numeroTriangulos, ResolveShapeName(numeroTriangulos, "shape_triangle", "shape_triangles"), areaTriangulos.ToString("#.##"), perimetroTriangulos.ToString("#.##")));
            if (numeroRectangulos > 0)
                sb.Append(string.Format(linea, numeroRectangulos, ResolveShapeName(numeroRectangulos, "shape_rectangle", "shape_rectangles"), areaRectangulos.ToString("#.##"), perimetroRectangulos.ToString("#.##")));
            if (numeroTrapecios > 0)
                sb.Append(string.Format(linea, numeroTrapecios, ResolveShapeName(numeroTrapecios, "shape_trapeze", "shape_trapezes"), areaTrapecios.ToString("#.##"), perimetroTrapecios.ToString("#.##")));
            // FOOTER
            var shapeSum = formas.Count;
            var perSum = formas.Sum(x => x.CalcularPerimetro());
            var areaSum = formas.Sum(x => x.CalcularArea());
            //TOTAL:<br/>{0} formas Perimetro {0} Area {0}
            sb.Append(string.Format(GetString("footer"), shapeSum, perSum.ToString("#.##"), areaSum.ToString("#.##")));
            #endregion

            return sb.ToString();
        }

        public abstract decimal CalcularArea();
        
        public abstract decimal CalcularPerimetro();

        protected virtual void Validar(decimal Valor1, decimal Valor2)
        {
            if (Valor1 == Valor2)
                throw new Exception(GetString("error_msg"));
        }

        internal static string GetString(string key)
        {
            var idioma = CultureInfo.CurrentCulture; ;
            return Resources.ResourceManager.GetString(key, idioma);
        }

        internal static string ResolveShapeName(int quantity, string single_key, string plural_key)
        {
            return quantity == 1 ? GetString(single_key) : GetString(plural_key);
        }
    }
}
