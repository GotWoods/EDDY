using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITD*7x*t*9*x5sGM4*7*fa2SZm*1*D*oWNVFA*y*8*9*9*E*2";

		var expected = new ITD_TermsOfSaleDeferredTermsOfSale()
		{
			TermsTypeCode = "7x",
			TermsBasisDateCode = "t",
			TermsDiscountPercent = 9,
			TermsDiscountDueDate = "x5sGM4",
			TermsDiscountDaysDue = 7,
			TermsNetDueDate = "fa2SZm",
			TermsNetDays = 1,
			TermsDiscountAmount = "D",
			TermsDeferredDueDate = "oWNVFA",
			DeferredAmountDue = "y",
			PercentOfInvoicePayable = 8,
			Description = "9",
			DayOfMonth = 9,
			PaymentMethodCode = "E",
			Percent = 2,
		};

		var actual = Map.MapObject<ITD_TermsOfSaleDeferredTermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", 0, 0, true)]
	[InlineData(9, "x5sGM4", 7, 9, true)]
	[InlineData(9, "", 0, 0, false)]
	[InlineData(0, "x5sGM4", 7, 9, true)]
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
			subject.TermsDiscountAmount = "D";
			subject.TermsDiscountDueDate = "x5sGM4";
			subject.TermsDiscountDaysDue = 7;
			subject.DayOfMonth = 9;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.DeferredAmountDue) || subject.PercentOfInvoicePayable > 0)
		{
			subject.TermsDeferredDueDate = "oWNVFA";
			subject.DeferredAmountDue = "y";
			subject.PercentOfInvoicePayable = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", 0, 0, true)]
	[InlineData("D", "x5sGM4", 7, 9, true)]
	[InlineData("D", "", 0, 0, false)]
	[InlineData("", "x5sGM4", 7, 9, true)]
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
			subject.TermsDiscountDueDate = "x5sGM4";
			subject.TermsDiscountDaysDue = 7;
			subject.DayOfMonth = 9;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.DeferredAmountDue) || subject.PercentOfInvoicePayable > 0)
		{
			subject.TermsDeferredDueDate = "oWNVFA";
			subject.DeferredAmountDue = "y";
			subject.PercentOfInvoicePayable = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("oWNVFA", "y", 8, true)]
	[InlineData("oWNVFA", "", 0, false)]
	[InlineData("", "y", 8, true)]
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
			subject.TermsDiscountDueDate = "x5sGM4";
			subject.TermsDiscountDaysDue = 7;
			subject.DayOfMonth = 9;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountDueDate) || subject.TermsDiscountDaysDue > 0 || subject.DayOfMonth > 0)
		{
			subject.TermsDiscountAmount = "D";
			subject.TermsDiscountDueDate = "x5sGM4";
			subject.TermsDiscountDaysDue = 7;
			subject.DayOfMonth = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
