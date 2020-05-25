namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        protected readonly decimal _base;
        protected readonly decimal _altura;
        public Rectangulo(decimal Base, decimal Altura)
        {
            base.Validar(Base, Altura);
            _base = Base;
            _altura = Altura;   
        }

        public override decimal CalcularArea()
        {
            return _base * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return _base * 2 + _altura * 2;
        }
    }
}
