using System;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        protected readonly decimal _lado;

        public  Circulo(decimal Ancho)
        {
            _lado = Ancho;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }
    }
}
