using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITD*ux*O*2*HzEox8Fm*2*pdGKpKpG*5*d*oVTe5ROi*O*1*d*7*D*6";

		var expected = new ITD_TermsOfSaleDeferredTermsOfSale()
		{
			TermsTypeCode = "ux",
			TermsBasisDateCode = "O",
			TermsDiscountPercent = 2,
			TermsDiscountDueDate = "HzEox8Fm",
			TermsDiscountDaysDue = 2,
			TermsNetDueDate = "pdGKpKpG",
			TermsNetDays = 5,
			TermsDiscountAmount = "d",
			TermsDeferredDueDate = "oVTe5ROi",
			DeferredAmountDue = "O",
			PercentOfInvoicePayable = 1,
			Description = "d",
			DayOfMonth = 7,
			PaymentMethodTypeCode = "D",
			PercentageAsDecimal = 6,
		};

		var actual = Map.MapObject<ITD_TermsOfSaleDeferredTermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", 0, 0, true)]
	[InlineData(2, "HzEox8Fm", 2, 7, true)]
	[InlineData(2, "", 0, 0, false)]
	[InlineData(0, "HzEox8Fm", 2, 7, true)]
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
			subject.TermsDiscountAmount = "d";
			subject.TermsDiscountDueDate = "HzEox8Fm";
			subject.TermsDiscountDaysDue = 2;
			subject.DayOfMonth = 7;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.DeferredAmountDue) || subject.PercentOfInvoicePayable > 0)
		{
			subject.TermsDeferredDueDate = "oVTe5ROi";
			subject.DeferredAmountDue = "O";
			subject.PercentOfInvoicePayable = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", 0, 0, true)]
	[InlineData("d", "HzEox8Fm", 2, 7, true)]
	[InlineData("d", "", 0, 0, false)]
	[InlineData("", "HzEox8Fm", 2, 7, true)]
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
			subject.TermsDiscountPercent = 2;
			subject.TermsDiscountDueDate = "HzEox8Fm";
			subject.TermsDiscountDaysDue = 2;
			subject.DayOfMonth = 7;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.TermsDeferredDueDate) || !string.IsNullOrEmpty(subject.DeferredAmountDue) || subject.PercentOfInvoicePayable > 0)
		{
			subject.TermsDeferredDueDate = "oVTe5ROi";
			subject.DeferredAmountDue = "O";
			subject.PercentOfInvoicePayable = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("oVTe5ROi", "O", 1, true)]
	[InlineData("oVTe5ROi", "", 0, false)]
	[InlineData("", "O", 1, true)]
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
			subject.TermsDiscountPercent = 2;
			subject.TermsDiscountDueDate = "HzEox8Fm";
			subject.TermsDiscountDaysDue = 2;
			subject.DayOfMonth = 7;
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountAmount) || !string.IsNullOrEmpty(subject.TermsDiscountDueDate) || subject.TermsDiscountDaysDue > 0 || subject.DayOfMonth > 0)
		{
			subject.TermsDiscountAmount = "d";
			subject.TermsDiscountDueDate = "HzEox8Fm";
			subject.TermsDiscountDaysDue = 2;
			subject.DayOfMonth = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
