using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PYTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PYT*1*db*8*2*2*wW*9*1";

		var expected = new PYT_HistoricalPaymentTerms()
		{
			TermsNetDays = 1,
			TermsTypeCode = "db",
			DayOfMonth = 8,
			TermsDiscountPercent = 2,
			TermsDiscountPercent2 = 2,
			TermsTypeCode2 = "wW",
			TermsDiscountDaysDue = 9,
			TermsDiscountDaysDue2 = 1,
		};

		var actual = Map.MapObject<PYT_HistoricalPaymentTerms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(1, "db", true)]
	[InlineData(1, "", true)]
	[InlineData(0, "db", true)]
	public void Validation_AtLeastOneTermsNetDays(int termsNetDays, string termsTypeCode, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		//Required fields
		//Test Parameters
		if (termsNetDays > 0) 
			subject.TermsNetDays = termsNetDays;
		subject.TermsTypeCode = termsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "db", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "db", true)]
	public void Validation_ARequiresBDayOfMonth(int dayOfMonth, string termsTypeCode, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		//Required fields
		//Test Parameters
		if (dayOfMonth > 0) 
			subject.DayOfMonth = dayOfMonth;
		subject.TermsTypeCode = termsTypeCode;
		//At Least one
		subject.TermsNetDays = 1;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 2, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 2, true)]
	public void Validation_ARequiresBTermsDiscountPercent2(decimal termsDiscountPercent2, decimal termsDiscountPercent, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		//Required fields
		//Test Parameters
		if (termsDiscountPercent2 > 0) 
			subject.TermsDiscountPercent2 = termsDiscountPercent2;
		if (termsDiscountPercent > 0) 
			subject.TermsDiscountPercent = termsDiscountPercent;
		//At Least one
		subject.TermsNetDays = 1;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("wW", 2, true)]
	[InlineData("wW", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBTermsTypeCode2(string termsTypeCode2, decimal termsDiscountPercent, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		//Required fields
		//Test Parameters
		subject.TermsTypeCode2 = termsTypeCode2;
		if (termsDiscountPercent > 0) 
			subject.TermsDiscountPercent = termsDiscountPercent;
		//At Least one
		subject.TermsNetDays = 1;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 9, true)]
	[InlineData(1, 0, false)]
	[InlineData(0, 9, true)]
	public void Validation_ARequiresBTermsDiscountDaysDue2(int termsDiscountDaysDue2, int termsDiscountDaysDue, bool isValidExpected)
	{
		var subject = new PYT_HistoricalPaymentTerms();
		//Required fields
		//Test Parameters
		if (termsDiscountDaysDue2 > 0) 
			subject.TermsDiscountDaysDue2 = termsDiscountDaysDue2;
		if (termsDiscountDaysDue > 0) 
			subject.TermsDiscountDaysDue = termsDiscountDaysDue;
		//At Least one
		subject.TermsNetDays = 1;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
