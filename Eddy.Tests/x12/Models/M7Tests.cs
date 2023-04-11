using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M7Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "M7*E*V*U*A*hO";

        var expected = new M7_SealNumbers()
        {
            SealNumber = "E",
            SealNumber2 = "V",
            SealNumber3 = "U",
            SealNumber4 = "A",
            EntityIdentifierCode = "hO",
        };

        var actual = Map.MapObject<M7_SealNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredSealNumber(string sealNumber, bool isValidExpected)
    {
        var subject = new M7_SealNumbers();
        subject.SealNumber = sealNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}