using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C035Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "b*D4*e";

        var expected = new C035_ProviderSpecialtyInformation()
        {
            ProviderSpecialtyCode = "b",
            AgencyQualifierCode = "D4",
            YesNoConditionOrResponseCode = "e",
        };

        var actual = Map.MapObject<C035_ProviderSpecialtyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("b", true)]
    public void Validatation_RequiredProviderSpecialtyCode(string providerSpecialtyCode, bool isValidExpected)
    {
        var subject = new C035_ProviderSpecialtyInformation();
        subject.ProviderSpecialtyCode = providerSpecialtyCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}