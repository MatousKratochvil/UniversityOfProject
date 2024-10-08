using System.Text.RegularExpressions;

namespace Core;

public partial class CoreRegex
{
    // regex for checking if the zip code contains letters
    [GeneratedRegex("[A-Za-z]")]
    public static partial Regex CheckForLetters();
    
    [GeneratedRegex("[A-Za-zÁáČčĎďÉéĚěÍíŇňÓóŘřŠšŤťÚúŮůÝýŽž]")]
    public static partial Regex CheckForLettersInCz();
}