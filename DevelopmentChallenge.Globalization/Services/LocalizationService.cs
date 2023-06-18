using System;
using System.IO;
using System.Resources;

namespace DevelopmentChallenge.Globalization.Services
{
    public class LocalizationService 
    {
        public string GetLocalizedString(int languageId)
        {
            ILocalizationService localizationService = LocalizationServiceFactory.GetLocalizationService();

            string resourcePath = localizationService.GetResourceFilePath(languageId);
            ResXResourceSet resourceSet = new ResXResourceSet(resourcePath);

            string texto = resourceSet.GetString("hola_mundo");
            return texto;
        }
    }

    public static class LocalizationServiceFactory
    {
        public static ILocalizationService GetLocalizationService()
        {
            // uso la fabrica para crear la instancia de la interface ILocalizationService 
            //y retorna la instancia para usarla en el metodo estatico
            return new LocalizationServiceImplementation();
        }
    }

    public class LocalizationServiceImplementation : ILocalizationService
    {
        public string GetResourceFilePath(int languageId)
        {
            string resourceFileName = $"Resources.{languageId}.resx";
            string resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", resourceFileName);
            return resourcePath;
        }
    }
}
