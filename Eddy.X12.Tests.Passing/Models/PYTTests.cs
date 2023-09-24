using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PYTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PYT*5*1I*9*3*4*rF*3*3";

		var expected = new PYT_HistoricalPaymentTerms()
		{
			TermsNetDays = 5,
			TermsTypeCode = "1I",
			DayOfMonth = 9,
			TermsDiscountPercent = 3,
			TermsDiscountPercent2 = 4,
			TermsTypeCode2 = "rF",
			TermsDiscountDaysDue = 3,
			TermsDiscountDaysDue2 = 3,
		};

		var actual = Map.MapObject<PYT_HistoricalPaymentTerms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", false)]
	[InlineData(5,"1I", true)]
	[InlineData(0, "1I", true)]
	[InlineData(5, "", true)]
	public void Validation_AtLeastOneTermsNetDays(int termsNetDays, string termsTypeCode, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		if (termsNetDays > 0)
		subject.TermsNetDays = termsNetDays;
		subject.TermsTypeCode = termsTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "1I", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBDayOfMonth(int dayOfMonth, string termsTypeCode, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		if (dayOfMonth > 0)
		subject.DayOfMonth = dayOfMonth;
		subject.TermsTypeCode = termsTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 3, true)]
	[InlineData(4, 0, false)]
	public void Validation_ARequiresBTermsDiscountPercent2(decimal termsDiscountPercent2, decimal termsDiscountPercent, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		if (termsDiscountPercent2 > 0)
		subject.TermsDiscountPercent2 = termsDiscountPercent2;
		if (termsDiscountPercent > 0)
		subject.TermsDiscountPercent = termsDiscountPercent;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 3, true)]
	[InlineData("rF", 0, false)]
	public void Validation_ARequiresBTermsTypeCode2(string termsTypeCode2, decimal termsDiscountPercent, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		subject.TermsTypeCode2 = termsTypeCode2;
		if (termsDiscountPercent > 0)
		subject.TermsDiscountPercent = termsDiscountPercent;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 3, true)]
	[InlineData(3, 0, false)]
	public void Validation_ARequiresBTermsDiscountDaysDue2(int termsDiscountDaysDue2, int termsDiscountDaysDue, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		if (termsDiscountDaysDue2 > 0)
		subject.TermsDiscountDaysDue2 = termsDiscountDaysDue2;
		if (termsDiscountDaysDue > 0)
		subject.TermsDiscountDaysDue = termsDiscountDaysDue;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
