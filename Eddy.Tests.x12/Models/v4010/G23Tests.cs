using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G23Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G23*mm*e*3LwuMHuf*E2*5*cnloTaln*5*yfUtzJLM*3*K*B*l*G*7*y*46";

		var expected = new G23_TermsOfSale()
		{
			TermsTypeCode = "mm",
			TermsBasisDateCode = "e",
			TermsStartDate = "3LwuMHuf",
			TermsDueDateQualifier = "E2",
			TermsDiscountPercent = 5,
			TermsDiscountDueDate = "cnloTaln",
			TermsDiscountDaysDue = 5,
			TermsNetDueDate = "yfUtzJLM",
			TermsNetDays = 3,
			TermsDiscountAmount = "K",
			DiscountedAmountDue = "B",
			AmountSubjectToTermsDiscount = "l",
			InstallmentTotalInvoiceAmountDue = "G",
			PercentOfInvoicePayable = 7,
			FreeFormMessage = "y",
			InstallmentGroupIndicator = 46,
		};

		var actual = Map.MapObject<G23_TermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mm", true)]
	public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsBasisDateCode = "e";
		subject.TermsTypeCode = termsTypeCode;
			subject.TermsNetDueDate = "yfUtzJLM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredTermsBasisDateCode(string termsBasisDateCode, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsTypeCode = "mm";
		subject.TermsBasisDateCode = termsBasisDateCode;
			subject.TermsNetDueDate = "yfUtzJLM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("yfUtzJLM", 3, true)]
	[InlineData("yfUtzJLM", 0, true)]
	[InlineData("", 3, true)]
	public void Validation_AtLeastOneTermsNetDueDate(string termsNetDueDate, int termsNetDays, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsTypeCode = "mm";
		subject.TermsBasisDateCode = "e";
		subject.TermsNetDueDate = termsNetDueDate;
		if (termsNetDays > 0)
			subject.TermsNetDays = termsNetDays;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
