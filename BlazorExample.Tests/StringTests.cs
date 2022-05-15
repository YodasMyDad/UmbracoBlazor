using Xunit;
using Xunit.Abstractions;

namespace BlazorExample.Tests;

public class StringTests
{
    private readonly ITestOutputHelper _output;
    public StringTests(ITestOutputHelper output)
    {
        _output = output;
    }

    
    [Fact]
    public void Can_Strip_UmbracoJsonShite()
    {
        var umbracoJson = @")]}',
                            true";
        var correctJson = "true";
        var strippedJson = umbracoJson.Remove(0, 9).Trim();
        _output.WriteLine(strippedJson);
        Assert.Equal(correctJson, strippedJson);
    }
}