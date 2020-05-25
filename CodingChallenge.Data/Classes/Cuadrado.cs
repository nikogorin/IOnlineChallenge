namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        protected readonly decimal _lado;

        public Cuadrado(decimal Ancho)
        {
            _lado = Ancho;
        }

        public override decimal CalcularArea()
        { 
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

    }
}
