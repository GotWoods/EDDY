using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMP*o*q*YM6*e";

		var expected = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement()
		{
			TransactionHandlingCode = "o",
			ReferenceNumber = "q",
			PaymentMethodCode = "YM6",
			ReferenceNumber2 = "e",
		};

		var actual = Map.MapObject<BMP_BeginningSegmentForMarketDevelopmentFundSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		//Required fields
		subject.ReferenceNumber = "q";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		//Required fields
		subject.TransactionHandlingCode = "o";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
