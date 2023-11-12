using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMP*i*m*i1C*K";

		var expected = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement()
		{
			TransactionHandlingCode = "i",
			ReferenceIdentification = "m",
			PaymentMethodCode = "i1C",
			ReferenceIdentification2 = "K",
		};

		var actual = Map.MapObject<BMP_BeginningSegmentForMarketDevelopmentFundSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		//Required fields
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		//Required fields
		subject.TransactionHandlingCode = "i";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
