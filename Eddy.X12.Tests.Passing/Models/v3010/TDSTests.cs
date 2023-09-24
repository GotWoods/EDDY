using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TDS*l*b*g*n";

		var expected = new TDS_TotalMonetaryValueSummary()
		{
			TotalInvoiceAmount = "l",
			AmountSubjectToTermsDiscount = "b",
			DiscountedAmountDue = "g",
			TermsDiscountAmount = "n",
		};

		var actual = Map.MapObject<TDS_TotalMonetaryValueSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTotalInvoiceAmount(string totalInvoiceAmount, bool isValidExpected)
	{
		var subject = new TDS_TotalMonetaryValueSummary();
		subject.TotalInvoiceAmount = totalInvoiceAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
