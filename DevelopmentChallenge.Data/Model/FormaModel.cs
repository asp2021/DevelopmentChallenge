namespace DevelopmentChallenge.Data.Model
{
    public class FormaModel
    {
        public string Nombre { get; set; }
        public decimal Perimetro { get; set; }
        public decimal Area { get; set; }

        public FormaModel(string nombre, decimal perimetro, decimal area)
        {
            Nombre = nombre;
            Perimetro = perimetro;
            Area = area;
        }
    }
}
