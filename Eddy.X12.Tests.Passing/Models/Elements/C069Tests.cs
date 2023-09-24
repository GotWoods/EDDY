using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C069Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ut*8T*NZ*bw*Lp*Jr*NM*St*zO*kD*a0*uj*uW*Y1*NY";

        var expected = new C069_CompositeStateOrProvinceCode()
        {
            StateOrProvinceCode = "ut",
            StateOrProvinceCode2 = "8T",
            StateOrProvinceCode3 = "NZ",
            StateOrProvinceCode4 = "bw",
            StateOrProvinceCode5 = "Lp",
            StateOrProvinceCode6 = "Jr",
            StateOrProvinceCode7 = "NM",
            StateOrProvinceCode8 = "St",
            StateOrProvinceCode9 = "zO",
            StateOrProvinceCode10 = "kD",
            StateOrProvinceCode11 = "a0",
            StateOrProvinceCode12 = "uj",
            StateOrProvinceCode13 = "uW",
            StateOrProvinceCode14 = "Y1",
            StateOrProvinceCode15 = "NY",
        };

        var actual = Map.MapObject<C069_CompositeStateOrProvinceCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("ut", true)]
    public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
    {
        var subject = new C069_CompositeStateOrProvinceCode();
        subject.StateOrProvinceCode = stateOrProvinceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}