using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*y7Z8ai*6*5*3*W*C*rQNETC*ifhp*wc*Tme";

		var expected = new FIR_FinancialInformation()
		{
			FinancialTransactionCode = "y7Z8ai",
			MonetaryAmount = 6,
			Quantity = 5,
			Quantity2 = 3,
			FinancialInformationTypeCode = "W",
			CreditDebitFlagCode = "C",
			Date = "rQNETC",
			Time = "ifhp",
			TimeCode = "wc",
			CurrencyCode = "Tme",
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y7Z8ai", true)]
	public void Validation_RequiredFinancialTransactionCode(string financialTransactionCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.FinancialTransactionCode = financialTransactionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wc", "ifhp", true)]
	[InlineData("wc", "", false)]
	[InlineData("", "ifhp", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.FinancialTransactionCode = "y7Z8ai";
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
