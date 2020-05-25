/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 * Para agregar un nuevo idioma, se deberá agregar un nuevo archivo de recursos con el idioma deseado.
 * para las formas geometricas nuevas, se tiene q crear una una clase, heredando de la clase formas e implementando los metodos abstractos que calculan el area y el perimetro. 
 * En la clase base, se tiene q agregar la logica de la nueva forma para el calculo e impresion de los resultado
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

            if (formas == null || !formas.Any()|| formas.Count == formas.Count(x => x == null))
                return GetString(Common.Constants.res_empty_list);

            // Hay por lo menos una forma
            #region Calcular Cuadrados
            var listCuadrados = formas.Where(x => x?.GetType() == typeof(Cuadrado)).ToList();
            var numeroCuadrados = listCuadrados.Count;
            var areaCuadrados = listCuadrados.Sum(x => x.CalcularArea());
            var perimetroCuadrados = listCuadrados.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Circulos
            var listCirculos = formas.Where(x => x?.GetType() == typeof(Circulo)).ToList();
            var numeroCirculos = listCirculos.Count;
            var areaCirculos = listCirculos.Sum(x => x.CalcularArea());
            var perimetroCirculos = listCirculos.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Triangulos
            var listTriangulos = formas.Where(x => x?.GetType() == typeof(Triangulo)).ToList();
            var numeroTriangulos = listTriangulos.Count;
            var areaTriangulos = listTriangulos.Sum(x => x.CalcularArea());
            var perimetroTriangulos = listTriangulos.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Rectangulo
            var listRectangulos = formas.Where(x => x?.GetType() == typeof(Rectangulo)).ToList();
            var numeroRectangulos = listRectangulos.Count;
            var areaRectangulos = listRectangulos.Sum(x => x.CalcularArea());
            var perimetroRectangulos = listRectangulos.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Calcular Trapecio
            var listTrapecios = formas.Where(x => x?.GetType() == typeof(Trapecio)).ToList();
            var numeroTrapecios = listTrapecios.Count;
            var areaTrapecios = listTrapecios.Sum(x => x.CalcularArea());
            var perimetroTrapecios = listTrapecios.Sum(x => x.CalcularPerimetro());
            #endregion

            #region Texto Impresion
            // HEADER
            sb.Append(GetString(Common.Constants.res_header));
            //BODY
            var linea = GetString(Common.Constants.res_body);//{0} {1} | Area {2} | Perimeter{3} <br/>
            if (numeroCuadrados > 0)
                sb.Append(string.Format(linea, numeroCuadrados, ResolveShapeName(numeroCuadrados, Common.Constants.res_shape_square, Common.Constants.res_shape_squares), areaCuadrados.ToString(Common.Constants.cons_numeric_format), perimetroCuadrados.ToString(Common.Constants.cons_numeric_format)));
            if (numeroCirculos > 0)
                sb.Append(string.Format(linea, numeroCirculos, ResolveShapeName(numeroCirculos, Common.Constants.res_shape_circle, Common.Constants.res_shape_circles), areaCirculos.ToString(Common.Constants.cons_numeric_format), perimetroCirculos.ToString(Common.Constants.cons_numeric_format)));
            if (numeroTriangulos > 0)
                sb.Append(string.Format(linea, numeroTriangulos, ResolveShapeName(numeroTriangulos, Common.Constants.res_shape_triangle, Common.Constants.res_shape_triangles), areaTriangulos.ToString(Common.Constants.cons_numeric_format), perimetroTriangulos.ToString(Common.Constants.cons_numeric_format)));
            if (numeroRectangulos > 0)
                sb.Append(string.Format(linea, numeroRectangulos, ResolveShapeName(numeroRectangulos, Common.Constants.res_shape_rectangle, Common.Constants.res_shape_rectangles), areaRectangulos.ToString(Common.Constants.cons_numeric_format), perimetroRectangulos.ToString(Common.Constants.cons_numeric_format)));
            if (numeroTrapecios > 0)
                sb.Append(string.Format(linea, numeroTrapecios, ResolveShapeName(numeroTrapecios, Common.Constants.res_shape_trapeze, Common.Constants.res_shape_trapezes), areaTrapecios.ToString(Common.Constants.cons_numeric_format), perimetroTrapecios.ToString(Common.Constants.cons_numeric_format)));
            // FOOTER
            var shapeSum = formas.Count(x => x != null);
            var perSum = formas.Sum(x => x?.CalcularPerimetro());
            var areaSum = formas.Sum(x => x?.CalcularArea());
            //TOTAL:<br/>{0} formas Perimetro {0} Area {0}
            sb.Append(string.Format(GetString(Common.Constants.res_footer), shapeSum, perSum?.ToString(Common.Constants.cons_numeric_format), areaSum?.ToString(Common.Constants.cons_numeric_format)));
            #endregion

            return sb.ToString();
        }

        public abstract decimal CalcularArea();
        
        public abstract decimal CalcularPerimetro();

        protected virtual void Validar(decimal valor1, decimal valor2)
        {
            if (valor1 == valor2)
                throw new Exception(GetString(Common.Constants.res_error_msg));
        }

        internal static string GetString(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new Exception(GetString(Common.Constants.res_empty_key));

            var idioma = CultureInfo.CurrentCulture; ;
            return Resources.ResourceManager.GetString(key, idioma);
        }

        internal static string ResolveShapeName(int quantity, string single_key, string plural_key)
        {
            return quantity == 1 ? GetString(single_key) : GetString(plural_key);
        }
    }
}
