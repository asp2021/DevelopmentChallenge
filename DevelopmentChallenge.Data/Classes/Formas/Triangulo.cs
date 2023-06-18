using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Triangulo : FormaGeometrica, IForma
    {
        public Triangulo(decimal lado)
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
            return ((decimal)Math.Sqrt(3) / 4) * this.lado * this.lado;
        }

        protected override decimal CalculatePerimeter()
        {
            return this.lado * 3;
        }
    }

}
