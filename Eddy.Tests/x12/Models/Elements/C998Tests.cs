using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C998Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "1*O";

        var expected = new C998_ContextIdentification()
        {
            ContextName = "1",
            ContextReference = "O",
        };

        var actual = Map.MapObject<C998_ContextIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("1", true)]
    public void Validatation_RequiredContextName(string contextName, bool isValidExpected)
    {
        var subject = new C998_ContextIdentification();
        subject.ContextName = contextName;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}