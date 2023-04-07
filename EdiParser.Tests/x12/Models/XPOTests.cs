using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class XPOTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "XPO*j*u*1*ca";

        var expected = new XPO_PreassignedPurchaseOrderNumbers()
        {
            PurchaseOrderNumber = "j",
            PurchaseOrderNumber2 = "u",
            IdentificationCodeQualifier = "1",
            IdentificationCode = "ca",
        };

        var actual = Map.MapObject<XPO_PreassignedPurchaseOrderNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("j", true)]
    public void Validatation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
    {
        var subject = new XPO_PreassignedPurchaseOrderNumbers();
        subject.PurchaseOrderNumber = purchaseOrderNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
    {
        var subject = new XPO_PreassignedPurchaseOrderNumbers();
        subject.PurchaseOrderNumber = "j";
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        subject.IdentificationCode = identificationCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}