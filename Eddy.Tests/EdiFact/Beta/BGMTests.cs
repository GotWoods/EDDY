using Eddy.Core.EdiFact.Mapping;
using Eddy.Core.EdiFact.Models.Beta;

namespace Eddy.Tests.EdiFact.Beta;

public class BGMTests
{
    [Fact]
    public void ShouldParse()
    {
        var expected = new BGM_BeginningOfMessage();
        expected.DocumentMessageName.Documentnamecode = "44";
        expected.DocumentMessageIdentification.DocumentIdentifier = "95-455";
        expected.MessageFunctionCode = "9";


        var options = new MapOptions();
        options.Separator = "+";
        var actual = Map.MapObject<BGM_BeginningOfMessage>("BGM+44+95-455+9", options);

        Assert.Equivalent(expected, actual);
    }
}