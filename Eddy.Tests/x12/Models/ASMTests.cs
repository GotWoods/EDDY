using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ASMTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ASM*5*D*8";

        var expected = new ASM_AmountAndSettlementMethod
        {
            Amount = "5",
            PaymentMethodTypeCode = "D",
            AmountQualifierCode = "8"
        };

        var actual = Map.MapObject<ASM_AmountAndSettlementMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("5", true)]
    public void Validatation_RequiredAmount(string amount, bool isValidExpected)
    {
        var subject = new ASM_AmountAndSettlementMethod();
        subject.Amount = amount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}