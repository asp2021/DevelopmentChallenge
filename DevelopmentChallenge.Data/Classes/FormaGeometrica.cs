using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Model;
using DevelopmentChallenge.Globalization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
    
namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        private static ILocalizationService _localizationService;

        #region Atributos
        protected decimal lado;
        #endregion

        #region constructor
        public FormaGeometrica()
        {
            _localizationService = LocalizationServiceFactory.GetLocalizationService();
        }
        #endregion

        #region Metodos
        protected abstract decimal CalculateArea();

        protected abstract decimal CalculatePerimeter();

        public static string Imprimir(List<FormaGeometrica> formas, Idioma idioma)
        {
            StringBuilder sb = new StringBuilder();

            string resourcePath = _localizationService.GetResourceFilePath((int)idioma);
            ResXResourceSet resourceSet = new ResXResourceSet(resourcePath);

            List<FormaModel> listFormas = new List<FormaModel>();
            Dictionary<string, int> cantidades = new Dictionary<string, int>();

            try
            {
                //No hay formas
                if (!formas.Any())
                {
                    return string.Format("<h1>{0}</h1>", resourceSet.GetString("Lista vacía de formas!"));
                }

                //Hay por lo menos una forma
                sb.Append(string.Format("<h1>{0}</h1>", resourceSet.GetString("Reporte de Formas")));

                foreach(IForma forma in formas)
                {
                    FormaModel formaModel = new FormaModel(forma.GetType().Name, forma.GetPerimeter, forma.GetArea);
                    FormaModel formaUpdate = listFormas.Find(f => f.Nombre == formaModel.Nombre);

                    if (formaUpdate != null)
                    {
                        formaUpdate.Perimetro += formaModel.Perimetro;
                        formaUpdate.Area += formaModel.Area;
                    }
                    else
                    {
                        listFormas.Add(formaModel);
                    }

                    if (!cantidades.ContainsKey(formaModel.Nombre))
                    {
                        cantidades.Add(formaModel.Nombre, 1);
                    }
                    else
                    {
                        cantidades[formaModel.Nombre]++;
                    }
                }
            
                foreach (FormaModel formaModel in listFormas)
                {
                    string key = formaModel.Nombre;
                    string descrip = cantidades[key] > 1 ? resourceSet.GetString(formaModel.Nombre) + "s" : resourceSet.GetString(formaModel.Nombre);
                    sb.Append( string.Format("{0} {1} | {2}: {3} | {4}: {5} |<br/>",
                                     cantidades[key],descrip,
                                     resourceSet.GetString("Perímetro"),formaModel.Perimetro.ToString("#.##"),
                                     resourceSet.GetString("Área"),formaModel.Area.ToString("#.##")
                        )
                    );
                }

                // FOOTER
                sb.Append(string.Format("{0}:<br/>", resourceSet.GetString("total").ToUpper()));
                sb.Append(
                    string.Format("{0} {1} |",
                                 cantidades.Sum(x => x.Value),
                                 cantidades.Sum(x => x.Value) > 1 ? resourceSet.GetString("Formas") : resourceSet.GetString("Forma")
                                 )
                );
                sb.Append( resourceSet.GetString("Perímetro") + ": " + formas
                    .Where(x => x is IForma)
                    .Sum(x => ((IForma)x).GetPerimeter)
                    .ToString("#.##")+ " | ");

                sb.Append( resourceSet.GetString("Área") + ": " + formas
                    .Where(x => x is IForma)
                    .Sum(x => ((IForma)x).GetArea)
                    .ToString("#.##")+ " |");

                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

    }
}
