using System;

namespace CodingChallenge.Data.Classes
{
    public class Triangulo : FormaGeometrica
    {
        protected readonly decimal _lado;

        public Triangulo(decimal Ancho)
        {
            _lado = Ancho;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
