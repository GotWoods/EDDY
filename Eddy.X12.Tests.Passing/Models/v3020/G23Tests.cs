using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G23Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G23*ph*o*8kwD8R*EJ*9*2njD8F*3*iEdJsE*1*d*h*y*F*7*7*99";

		var expected = new G23_TermsOfSale()
		{
			TermsTypeCode = "ph",
			TermsBasisDateCode = "o",
			TermsStartDate = "8kwD8R",
			TermsDueDateQualifier = "EJ",
			TermsDiscountPercent = 9,
			TermsDiscountDueDate = "2njD8F",
			TermsDiscountDaysDue = 3,
			TermsNetDueDate = "iEdJsE",
			TermsNetDays = 1,
			TermsDiscountAmount = "d",
			DiscountedAmountDue = "h",
			AmountSubjectToTermsDiscount = "y",
			InstallmentTotalInvoiceAmountDue = "F",
			PercentOfInvoicePayable = 7,
			FreeFormMessage = "7",
			InstallmentGroupIndicator = 99,
		};

		var actual = Map.MapObject<G23_TermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ph", true)]
	public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsBasisDateCode = "o";
		subject.TermsTypeCode = termsTypeCode;
			subject.TermsNetDueDate = "iEdJsE";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredTermsBasisDateCode(string termsBasisDateCode, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsTypeCode = "ph";
		subject.TermsBasisDateCode = termsBasisDateCode;
			subject.TermsNetDueDate = "iEdJsE";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("iEdJsE", 1, true)]
	[InlineData("iEdJsE", 0, true)]
	[InlineData("", 1, true)]
	public void Validation_AtLeastOneTermsNetDueDate(string termsNetDueDate, int termsNetDays, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsTypeCode = "ph";
		subject.TermsBasisDateCode = "o";
		subject.TermsNetDueDate = termsNetDueDate;
		if (termsNetDays > 0)
			subject.TermsNetDays = termsNetDays;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
