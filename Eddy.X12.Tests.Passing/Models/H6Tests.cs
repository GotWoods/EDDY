using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class H6Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "H6*9C*cK*1*1*2*7*h";

        var expected = new H6_SpecialServices()
        {
            SpecialServicesCode = "9C",
            SpecialServicesCode2 = "cK",
            QuantityOfPalletsShipped = 1,
            PalletExchangeCode = "1",
            Weight = 2,
            WeightUnitCode = "7",
            PickupOrDeliveryCode = "h",
        };

        var actual = Map.MapObject<H6_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", false)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_AtLeastOneSpecialServicesCode(string specialServicesCode, string pickupOrDeliveryCode, bool isValidExpected)
    {
        var subject = new H6_SpecialServices();
        subject.SpecialServicesCode = specialServicesCode;
        subject.PickupOrDeliveryCode = pickupOrDeliveryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

}