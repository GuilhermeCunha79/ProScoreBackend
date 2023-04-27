using System.Globalization;
using System.Reflection;
using System.Resources;
public class ResourceHelper
{
    private static ResourceManager _resourceManager;

    static ResourceHelper()
    {
        _resourceManager = new ResourceManager("ConsoleApp1.Domain.Language.string", Assembly.GetExecutingAssembly());
    }

    public static string GetString(string name)
    {
        return _resourceManager.GetString(name);
    }

    public static void ChangeLanguage(string language)
    {
        var cultureInfo = new CultureInfo(language);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
    }
}