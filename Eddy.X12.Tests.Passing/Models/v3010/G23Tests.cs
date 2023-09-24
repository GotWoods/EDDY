using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G23Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G23*d3*d*BHnsll*D7*1*6KKSvJ*6*fBPIrX*3*d*J*U*n*2*z*95";

		var expected = new G23_TermsOfSale()
		{
			TermsTypeCode = "d3",
			TermsBasisDateCode = "d",
			TermsStartDate = "BHnsll",
			TermsDueDateQualifier = "D7",
			TermsDiscountPercent = 1,
			TermsDiscountDueDate = "6KKSvJ",
			TermsDiscountDaysDue = 6,
			TermsNetDueDate = "fBPIrX",
			TermsNetDays = 3,
			TermsDiscountAmount = "d",
			DiscountedAmountDue = "J",
			AmountSubjectToTermsDiscount = "U",
			InstallmentTotalInvoiceAmountDue = "n",
			PercentOfInvoicePayable = 2,
			FreeFormMessage = "z",
			InstallmentGroupIndicator = 95,
		};

		var actual = Map.MapObject<G23_TermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d3", true)]
	public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsBasisDateCode = "d";
		subject.TermsStartDate = "BHnsll";
		subject.TermsTypeCode = termsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredTermsBasisDateCode(string termsBasisDateCode, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsTypeCode = "d3";
		subject.TermsStartDate = "BHnsll";
		subject.TermsBasisDateCode = termsBasisDateCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BHnsll", true)]
	public void Validation_RequiredTermsStartDate(string termsStartDate, bool isValidExpected)
	{
		var subject = new G23_TermsOfSale();
		subject.TermsTypeCode = "d3";
		subject.TermsBasisDateCode = "d";
		subject.TermsStartDate = termsStartDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
