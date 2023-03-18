using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ITDTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "ITD*f5*c*g*J3qLztG7*O*kDQBgu3F*K*e*0HCeaiXx*B*K*M*v*M*7";

        var expected = new ITD_TermsOfSaleDeferredTermsOfSale()
        {
            TermsTypeCode = "f5",
            TermsBasisDateCode = "c",
            TermsDiscountPercent = "g",
            TermsDiscountDueDate = "J3qLztG7",
            TermsDiscountDaysDue = "O",
            TermsNetDueDate = "kDQBgu3F",
            TermsNetDays = "K",
            TermsDiscountAmount = "e",
            TermsDeferredDueDate = "0HCeaiXx",
            DeferredAmountDue = "B",
            PercentOfInvoicePayable = "K",
            Description = "M",
            DayOfMonth = "v",
            PaymentMethodTypeCode = "M",
            PercentageAsDecimal = "7",
        };

        var actual = Map.MapObject<ITD_TermsOfSaleDeferredTermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    //TODO: Re-enable this
    // [Theory]
    // [InlineData("", "", true)]
    // [InlineData("v1", "v2", false)]
    // [InlineData("", "v2", true)]
    // [InlineData("v1", "", true)]
    // public void Validation_NEWTermsDiscountPercent(string termsDiscountPercent, string termsDiscountDueDate, string termsDiscountDaysDue, string dayOfMonth, bool isValidExpected)
    // {
    //     var subject = new ITD_TermsOfSaleDeferredTermsOfSale();
    //     subject.TermsDiscountPercent = termsDiscountPercent;
    //     subject.TermsDiscountDueDate = termsDiscountDueDate;
    //     subject.TermsDiscountDaysDue = termsDiscountDaysDue;
    //     subject.DayOfMonth = dayOfMonth;
    //
    //     TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
    // }
    // [Theory]
    // [InlineData("", "", true)]
    // [InlineData("v1", "v2", false)]
    // [InlineData("", "v2", true)]
    // [InlineData("v1", "", true)]
    // public void Validation_NEWTermsDiscountAmount(string termsDiscountAmount, string termsDiscountDueDate, string termsDiscountDaysDue, string dayOfMonth, bool isValidExpected)
    // {
    //     var subject = new ITD_TermsOfSaleDeferredTermsOfSale();
    //     subject.TermsDiscountAmount = termsDiscountAmount;
    //     subject.TermsDiscountDueDate = termsDiscountDueDate;
    //     subject.TermsDiscountDaysDue = termsDiscountDaysDue;
    //     subject.DayOfMonth = dayOfMonth;
    //
    //     TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
    // }
    // [Theory]
    // [InlineData("", "", true)]
    // [InlineData("v1", "v2", false)]
    // [InlineData("", "v2", true)]
    // [InlineData("v1", "", true)]
    // public void Validation_NEWTermsDeferredDueDate(string termsDeferredDueDate, string deferredAmountDue, string percentOfInvoicePayable, bool isValidExpected)
    // {
    //     var subject = new ITD_TermsOfSaleDeferredTermsOfSale();
    //     subject.TermsDeferredDueDate = termsDeferredDueDate;
    //     subject.DeferredAmountDue = deferredAmountDue;
    //     subject.PercentOfInvoicePayable = percentOfInvoicePayable;
    //
    //     TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
    // }
}