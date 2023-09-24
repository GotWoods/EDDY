using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C078Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "*2*3*P";

        var expected = new C078_CompositeDangerousGoodsSubsidiaryClassificationCodes()
        {
            SubsidiaryClassificationCode = "2",
            SubsidiaryClassificationCode2 = "3",
            SubsidiaryClassificationCode3 = "P",
        };

        var actual = Map.MapObject<C078_CompositeDangerousGoodsSubsidiaryClassificationCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("2", true)]
    public void Validation_RequiredSubsidiaryClassificationCode(string subsidiaryClassificationCode, bool isValidExpected)
    {
        var subject = new C078_CompositeDangerousGoodsSubsidiaryClassificationCodes();
        //Required fields
        //Test Parameters
        subject.SubsidiaryClassificationCode = subsidiaryClassificationCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("P", "3", true)]
    [InlineData("P", "", false)]
    [InlineData("", "3", true)]
    public void Validation_ARequiresBSubsidiaryClassificationCode3(string subsidiaryClassificationCode3, string subsidiaryClassificationCode2, bool isValidExpected)
    {
        var subject = new C078_CompositeDangerousGoodsSubsidiaryClassificationCodes();
        //Required fields
        subject.SubsidiaryClassificationCode = "2";
        //Test Parameters
        subject.SubsidiaryClassificationCode3 = subsidiaryClassificationCode3;
        subject.SubsidiaryClassificationCode2 = subsidiaryClassificationCode2;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}