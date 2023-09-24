using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class FIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIR*1gRcIx*8*6*3*e*F*MOHXsO*B0Iw*n2*3Ap";

		var expected = new FIR_FinancialInformation()
		{
			FinancialTransactionCode = "1gRcIx",
			MonetaryAmount = 8,
			Quantity = 6,
			Quantity2 = 3,
			FinancialInformationTypeCode = "e",
			CreditDebitFlagCode = "F",
			Date = "MOHXsO",
			Time = "B0Iw",
			TimeCode = "n2",
			CurrencyCode = "3Ap",
		};

		var actual = Map.MapObject<FIR_FinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1gRcIx", true)]
	public void Validation_RequiredFinancialTransactionCode(string financialTransactionCode, bool isValidExpected)
	{
		var subject = new FIR_FinancialInformation();
		subject.FinancialTransactionCode = financialTransactionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
