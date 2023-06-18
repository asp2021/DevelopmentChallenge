using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Formas;
using DevelopmentChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Klimber Challengue";
            try
            {
                Thread hilo = new Thread(new ThreadStart(StartProceso));
                hilo.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }

        public static void StartProceso()
        {
            // Spanish
            List<FormaGeometrica> formas =  new List<FormaGeometrica>();
            formas.Add( new Circulo(2));
            formas.Add( new Rectangulo(2, 2));
            formas.Add( new Cuadrado(2) );
            formas.Add( new Triangulo(2) );
            formas.Add(new Trapecio(4, 2, 5, 2));

            Console.WriteLine(FormaGeometrica.Imprimir(formas, Idioma.Español));

            // English
            formas = new List<FormaGeometrica>();
            formas.Add(new Circulo(2));
            formas.Add(new Rectangulo(2, 2));
            formas.Add(new Cuadrado(2));
            formas.Add(new Triangulo(2));
            formas.Add(new Trapecio(4, 2, 5, 2));

            Console.WriteLine(FormaGeometrica.Imprimir(formas, Idioma.Ingles));

            // Italian
            formas = new List<FormaGeometrica>();
            formas.Add(new Circulo(2));
            formas.Add(new Rectangulo(2, 2));
            formas.Add(new Cuadrado(2));
            formas.Add(new Triangulo(2));
            formas.Add(new Trapecio(4, 2, 5, 2));

            Console.WriteLine(FormaGeometrica.Imprimir(formas, Idioma.Italiano));
        }
    }
}
