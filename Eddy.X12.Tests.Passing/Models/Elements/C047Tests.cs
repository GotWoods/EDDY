using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C047Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "5e*s9*u1*Ck*TJ";

        var expected = new C047_CompositeTypeOfRealEstateAssetCode()
        {
            TypeOfRealEstateAssetCode = "5e",
            TypeOfRealEstateAssetCode2 = "s9",
            TypeOfRealEstateAssetCode3 = "u1",
            TypeOfRealEstateAssetCode4 = "Ck",
            TypeOfRealEstateAssetCode5 = "TJ",
        };

        var actual = Map.MapObject<C047_CompositeTypeOfRealEstateAssetCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("5e", true)]
    public void Validation_RequiredTypeOfRealEstateAssetCode(string typeOfRealEstateAssetCode, bool isValidExpected)
    {
        var subject = new C047_CompositeTypeOfRealEstateAssetCode();
        subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "Ck", true)]
    [InlineData("TJ", "", false)]
    public void Validation_ARequiresBTypeOfRealEstateAssetCode5(string typeOfRealEstateAssetCode5, string typeOfRealEstateAssetCode4, bool isValidExpected)
    {
        var subject = new C047_CompositeTypeOfRealEstateAssetCode();
        subject.TypeOfRealEstateAssetCode = "5e";
        subject.TypeOfRealEstateAssetCode5 = typeOfRealEstateAssetCode5;
        subject.TypeOfRealEstateAssetCode4 = typeOfRealEstateAssetCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}