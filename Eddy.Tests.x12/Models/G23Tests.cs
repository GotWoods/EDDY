using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G23Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "G23*Wr*8*YikFnF7Z*vl*7*lyhLpA85*2*2Fe5FP9p*7*Y*K*3*h*9*7*87";

        var expected = new G23_TermsOfSale
        {
            TermsTypeCode = "Wr",
            TermsBasisDateCode = "8",
            TermsStartDate = "YikFnF7Z",
            TermsDueDateQualifier = "vl",
            TermsDiscountPercent = 7,
            TermsDiscountDueDate = "lyhLpA85",
            TermsDiscountDaysDue = 2,
            TermsNetDueDate = "2Fe5FP9p",
            TermsNetDays = 7,
            TermsDiscountAmount = "Y",
            DiscountedAmountDue = "K",
            AmountSubjectToTermsDiscount = "3",
            InstallmentTotalInvoiceAmountDue = "h",
            PercentOfInvoicePayable = 9,
            FreeFormMessage = "7",
            InstallmentGroupIndicator = 87
        };

        var actual = Map.MapObject<G23_TermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Wr", true)]
    public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
    {
        var subject = new G23_TermsOfSale();
        subject.TermsBasisDateCode = "8";
        subject.TermsTypeCode = termsTypeCode;
        subject.TermsNetDays = 30;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("8", true)]
    public void Validation_RequiredTermsBasisDateCode(string termsBasisDateCode, bool isValidExpected)
    {
        var subject = new G23_TermsOfSale();
        subject.TermsTypeCode = "Wr";
        subject.TermsBasisDateCode = termsBasisDateCode;
        subject.TermsNetDays = 30;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, false)]
    [InlineData("2Fe5FP9p", 7, true)]
    [InlineData("", 7, true)]
    [InlineData("2Fe5FP9p", 0, true)]
    public void Validation_AtLeastOneTermsNetDueDate(string termsNetDueDate, int termsNetDays, bool isValidExpected)
    {
        var subject = new G23_TermsOfSale();
        subject.TermsTypeCode = "Wr";
        subject.TermsBasisDateCode = "8";
        subject.TermsNetDueDate = termsNetDueDate;
        if (termsNetDays > 0)
            subject.TermsNetDays = termsNetDays;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
}