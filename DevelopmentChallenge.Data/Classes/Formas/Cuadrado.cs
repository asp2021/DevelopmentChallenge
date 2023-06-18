using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Cuadrado : FormaGeometrica, IForma
    {
        public Cuadrado(decimal lado)
        {
            this.lado = lado;
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
            return this.lado * this.lado;
        }

        protected override decimal CalculatePerimeter()
        {
            return this.lado * 4;
        }
    }
}
