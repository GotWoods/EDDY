using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*4kDzmd*7*7*9*7*J*FYzoNo*qa5A*sX*aQH";

		var expected = new FIR_FinancialInformation()
		{
			FinancialTransactionCode = "4kDzmd",
			MonetaryAmount = 7,
			Quantity = 7,
			Quantity2 = 9,
			FinancialInformationTypeCode = "7",
			CreditDebitFlagCode = "J",
			Date = "FYzoNo",
			Time = "qa5A",
			TimeCode = "sX",
			CurrencyCode = "aQH",
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4kDzmd", true)]
	public void Validation_RequiredFinancialTransactionCode(string financialTransactionCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.FinancialTransactionCode = financialTransactionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sX", "qa5A", true)]
	[InlineData("sX", "", false)]
	[InlineData("", "qa5A", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.FinancialTransactionCode = "4kDzmd";
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
