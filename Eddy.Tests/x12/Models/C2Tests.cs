using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class C2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "C2*N*2*vI*23G*uS3wwG*c*7el0xfei";

        var expected = new C2_BankID()
        {
            BankClientCode = "N",
            IdentificationCodeQualifier = "2",
            IdentificationCode = "vI",
            ClientBankNumber = "23G",
            BankAccountNumber = "uS3wwG",
            PaymentMethodTypeCode = "c",
            Date = "7el0xfei",
        };

        var actual = Map.MapObject<C2_BankID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v", true)]
    public void Validatation_RequiredBankClientCode(string bankClientCode, bool isValidExpected)
    {
        var subject = new C2_BankID();
        subject.IdentificationCode = "12";
        subject.IdentificationCodeQualifier = "A";

        subject.BankClientCode = bankClientCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
    {
        var subject = new C2_BankID();
        subject.IdentificationCode = "12";
        subject.BankClientCode = "A";

        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
    {
        var subject = new C2_BankID();
        subject.IdentificationCodeQualifier = "A";
        subject.BankClientCode = "A";

        subject.IdentificationCode = identificationCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}