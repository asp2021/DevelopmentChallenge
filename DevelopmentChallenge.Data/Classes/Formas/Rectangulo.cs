using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Rectangulo : FormaGeometrica, IForma
    {
        private decimal lado2;

        public Rectangulo(decimal lado, decimal lado2)
        {
            this.lado = lado;
            this.lado2 = lado2;
        }

        public decimal GetArea
        {
            get
            {
                return CalculateArea();
            }
        }

        public decimal GetPerimeter
        {
            get
            {
                return CalculatePerimeter();
            }
        }

        protected override decimal CalculateArea()
        {
            return this.lado * this.lado2;
        }

        protected override decimal CalculatePerimeter()
        {
            return 2 * (this.lado + this.lado2);
        }
    }
}
