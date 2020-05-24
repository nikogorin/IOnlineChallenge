using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        protected readonly decimal _baseMenor;
        protected readonly decimal _baseMayor;
        protected readonly decimal _ladoIzquierdo;
        protected readonly decimal _ladoDerecho;
        protected readonly decimal _altura;

        public Trapecio(decimal BaseMenor, decimal BaseMayor, decimal LadoIzquierdo, decimal LadoDerecho, decimal Altura)
        {
            base.Validar(BaseMenor, BaseMayor);
            _baseMenor = BaseMenor;
            _baseMayor = BaseMayor;
            _ladoIzquierdo = LadoIzquierdo;
            _ladoDerecho = LadoDerecho;
            _altura = Altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMenor + _baseMayor + _ladoIzquierdo + _ladoDerecho;
        }

        //private void ValidarBases(decimal BaseMenor, decimal BaseMayor)
        //{
        //    if (BaseMenor == BaseMayor)
        //        throw new Exception("Los valores para las bases de la figura no corresponden a un trapecio");
        //}
    }
}
