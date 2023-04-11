using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C062Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "Y*k";

        var expected = new C062_TaxAdvantageAccountInformation()
        {
            AccountRelationshipCode = "Y",
            AccountNumber = "k",
        };

        var actual = Map.MapObject<C062_TaxAdvantageAccountInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Y", true)]
    public void Validation_RequiredAccountRelationshipCode(string accountRelationshipCode, bool isValidExpected)
    {
        var subject = new C062_TaxAdvantageAccountInformation();
        subject.AccountRelationshipCode = accountRelationshipCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}