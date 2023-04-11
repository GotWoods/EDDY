using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ACTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ACT*O*n*v*bQ*G*9*M*q*O";

        var expected = new ACT_AccountIdentification
        {
            AccountNumber = "O",
            Name = "n",
            IdentificationCodeQualifier = "v",
            IdentificationCode = "bQ",
            AccountNumberQualifier = "G",
            AccountNumber2 = "9",
            Description = "M",
            PaymentMethodTypeCode = "q",
            BenefitStatusCode = "O"
        };

        var actual = Map.MapObject<ACT_AccountIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("O", true)]
    public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
    {
        var subject = new ACT_AccountIdentification();
        subject.AccountNumber = accountNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v", "bQ", true)]
    [InlineData("", "bQ", false)]
    [InlineData("v", "", false)]
    public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
    {
        var subject = new ACT_AccountIdentification();
        subject.AccountNumber = "O";
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        subject.IdentificationCode = identificationCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "9", true)]
    [InlineData("G", "", false)]
    public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber2, bool isValidExpected)
    {
        var subject = new ACT_AccountIdentification();
        subject.AccountNumber = "O";
        subject.AccountNumberQualifier = accountNumberQualifier;
        subject.AccountNumber2 = accountNumber2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "G", true)]
    [InlineData("M", "", false)]
    public void Validation_ARequiresBDescription(string description, string accountNumberQualifier, bool isValidExpected)
    {
        var subject = new ACT_AccountIdentification();
        subject.AccountNumber = "O";
        subject.Description = description;
        subject.AccountNumberQualifier = accountNumberQualifier;
        if (accountNumberQualifier != "")
            subject.AccountNumber2 = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}