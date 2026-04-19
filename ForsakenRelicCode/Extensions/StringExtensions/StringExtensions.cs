namespace ForsakenRelic.ForsakenRelicCode.Extensions.StringExtensions;

//Mostly utilities to get asset paths.
public static class StringExtensions
{

    public static string BigRelicImagePath(this string path)
    {
        return Path.Join(MainFile.ModId, "images", "relics", "large", path);
    }
    
    public static string SmallRelicImagePath(this string path)
    {
        return Path.Join(MainFile.ModId, "images", "relics", "small", path);
    }
    
    public static string OutlineRelicImagePath(this string path)
    {
        return Path.Join(MainFile.ModId, "images", "relics", "outline", path);
    }
}