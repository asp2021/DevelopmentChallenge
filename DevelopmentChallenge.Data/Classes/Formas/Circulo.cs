using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Circulo: FormaGeometrica, IForma
    {
        public Circulo(decimal lado)
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
            return (decimal)Math.PI * (decimal)Math.Pow((double)this.lado, 2);
        }

        protected override decimal CalculatePerimeter()
        {
            return 2 * (decimal)Math.PI * this.lado;
        }
    }
}
