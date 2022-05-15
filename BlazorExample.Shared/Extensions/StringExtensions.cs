namespace BlazorExample.Shared.Extensions;

public static class StringExtensions
{
    public static string RemoveUmbracoAngularStartJson(this string json)
    {
        return json.Remove(0, 5).Trim();
    }
}