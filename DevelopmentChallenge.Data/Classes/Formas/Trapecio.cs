using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Trapecio : FormaGeometrica, IForma
    {
        private decimal baseMayor;
        private decimal baseMenor;
        private decimal lado2;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal lado, decimal lado2)
        {
            this.baseMayor = baseMayor;
            this.baseMenor = baseMenor;
            this.lado = lado;
            this.lado2 = lado2;

            if (this.baseMayor == 0 || this.baseMenor == 0)
                throw new ArgumentException("Las bases deben tener distinto valor de cero");
            else if (this.baseMenor > this.baseMayor)
                throw new ArgumentException("La base mayor debe ser un valor numérico superior a la base menor");
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
            return (this.baseMayor * this.baseMenor) / 2 * lado2;
        }

        protected override decimal CalculatePerimeter()
        {
            return (this.baseMenor + this.baseMayor + (2 * this.lado));
        }
    }
}
