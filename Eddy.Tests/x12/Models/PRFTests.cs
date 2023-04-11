using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRFTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "PRF*AUguQ3TimDSGxaJkGpKO0T*NbuFJMLqB5eZJJ7joISIEoPIbiziAq*KrIiGeYa*khicVJLF*jdrgOgIL3lI95jdQcKvJ*Kgclx0vBbUVIl17tEUvkhMHIT2rZ3V*Jg";

        var expected = new PRF_PurchaseOrderReference()
        {
            PurchaseOrderNumber = "AUguQ3TimDSGxaJkGpKO0T",
            ReleaseNumber = "NbuFJMLqB5eZJJ7joISIEoPIbiziAq",
            ChangeOrderSequenceNumber = "KrIiGeYa",
            Date = "khicVJLF",
            AssignedIdentification = "jdrgOgIL3lI95jdQcKvJ",
            ContractNumber = "Kgclx0vBbUVIl17tEUvkhMHIT2rZ3V",
            PurchaseOrderTypeCode = "Jg",
        };

        var actual = Map.MapObject<PRF_PurchaseOrderReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("AUguQ3TimDSGxaJkGpKO0T", true)]
    public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
    {
        var subject = new PRF_PurchaseOrderReference();
        subject.PurchaseOrderNumber = purchaseOrderNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}