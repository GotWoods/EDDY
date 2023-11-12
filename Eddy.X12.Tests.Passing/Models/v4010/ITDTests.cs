using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITD*Eh*g*9*MeasSiAO*6*sS3fqabn*1*n*qORz5qCL*0*3*Z*7*Z*9";

		var expected = new ITD_TermsOfSaleDeferredTermsOfSale()
		{
			TermsTypeCode = "Eh",
			TermsBasisDateCode = "g",
			TermsDiscountPercent = 9,
			TermsDiscountDueDate = "MeasSiAO",
			TermsDiscountDaysDue = 6,
			TermsNetDueDate = "sS3fqabn",
			TermsNetDays = 1,
			TermsDiscountAmount = "n",
			TermsDeferredDueDate = "qORz5qCL",
			DeferredAmountDue = "0",
			PercentOfInvoicePayable = 3,
			Description = "Z",
			DayOfMonth = 7,
			PaymentMethodCode = "Z",
			Percent = 9,
		};

		var actual = Map.MapObject<ITD_TermsOfSaleDeferredTermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", 0, 0, true)]
	[InlineData(9, "MeasSiAO", 6, 7, true)]
	[InlineData(9, "", 0, 0, false)]
	[InlineData(0, "MeasSiAO", 6, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TermsDiscountPercent(decimal termsDiscountPercent, string termsDiscountDueDate, int termsDiscountDaysDue, int dayOfMonth, bool isValidExpected)
	{
		var subject = new ITD_TermsOfSaleDeferredTermsOfSale();
		if (termsDiscountPercent > 0)
			subject.TermsDiscountPercent = termsDiscountPercent;
		subject.TermsDiscountDueDate = termsDiscountDueDate;
		if (termsDiscountDaysDue > 0)
			subject.TermsDiscountDaysDue = termsDiscountDaysDue;
		if (dayOfMonth > 0)
			subject.DayOfMonth = dayOfMonth;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountDueDate) || subject.TermsDiscountDaysDue > 0 || subject.DayOfMonth > 0)
		{
			subject.TermsDiscountAmount = "n";
			subject.TermsDiscountDueDate = "MeasSiAO";
			subject.TermsDiscountDaysDue = 6;
			subject.DayOfMonth = 7;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.DeferredAmountDue) || subject.PercentOfInvoicePayable > 0)
		{
			subject.TermsDeferredDueDate = "qORz5qCL";
			subject.DeferredAmountDue = "0";
			subject.PercentOfInvoicePayable = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", 0, 0, true)]
	[InlineData("n", "MeasSiAO", 6, 7, true)]
	[InlineData("n", "", 0, 0, false)]
	[InlineData("", "MeasSiAO", 6, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TermsDiscountAmount(string termsDiscountAmount, string termsDiscountDueDate, int termsDiscountDaysDue, int dayOfMonth, bool isValidExpected)
	{
		var subject = new ITD_TermsOfSaleDeferredTermsOfSale();
		subject.TermsDiscountAmount = termsDiscountAmount;
		subject.TermsDiscountDueDate = termsDiscountDueDate;
		if (termsDiscountDaysDue > 0)
			subject.TermsDiscountDaysDue = termsDiscountDaysDue;
		if (dayOfMonth > 0)
			subject.DayOfMonth = dayOfMonth;
		//If one is filled, at least one more is required
		if(subject.TermsDiscountPercent > 0 || subject.TermsDiscountPercent > 0 || !string.IsNullOrEmpty(subject.TermsDiscountDueDate) || subject.TermsDiscountDaysDue > 0 || subject.DayOfMonth > 0)
		{
			subject.TermsDiscountPercent = 9;
			subject.TermsDiscountDueDate = "MeasSiAO";
			subject.TermsDiscountDaysDue = 6;
			subject.DayOfMonth = 7;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.DeferredAmountDue) || subject.PercentOfInvoicePayable > 0)
		{
			subject.TermsDeferredDueDate = "qORz5qCL";
			subject.DeferredAmountDue = "0";
			subject.PercentOfInvoicePayable = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("qORz5qCL", "0", 3, true)]
	[InlineData("qORz5qCL", "", 0, false)]
	[InlineData("", "0", 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TermsDeferredDueDate(string termsDeferredDueDate, string deferredAmountDue, decimal percentOfInvoicePayable, bool isValidExpected)
	{
		var subject = new ITD_TermsOfSaleDeferredTermsOfSale();
		subject.TermsDeferredDueDate = termsDeferredDueDate;
		subject.DeferredAmountDue = deferredAmountDue;
		if (percentOfInvoicePayable > 0)
			subject.PercentOfInvoicePayable = percentOfInvoicePayable;
		//If one is filled, at least one more is required
		if(subject.TermsDiscountPercent > 0 || subject.TermsDiscountPercent > 0 || !string.IsNullOrEmpty(subject.TermsDiscountDueDate) || subject.TermsDiscountDaysDue > 0 || subject.DayOfMonth > 0)
		{
			subject.TermsDiscountPercent = 9;
			subject.TermsDiscountDueDate = "MeasSiAO";
			subject.TermsDiscountDaysDue = 6;
			subject.DayOfMonth = 7;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountDueDate) || subject.TermsDiscountDaysDue > 0 || subject.DayOfMonth > 0)
		{
			subject.TermsDiscountAmount = "n";
			subject.TermsDiscountDueDate = "MeasSiAO";
			subject.TermsDiscountDaysDue = 6;
			subject.DayOfMonth = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
