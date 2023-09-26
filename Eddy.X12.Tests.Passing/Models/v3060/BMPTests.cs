using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMP*a*3*FLA*g";

		var expected = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement()
		{
			TransactionHandlingCode = "a",
			ReferenceIdentification = "3",
			PaymentMethodCode = "FLA",
			ReferenceIdentification2 = "g",
		};

		var actual = Map.MapObject<BMP_BeginningSegmentForMarketDevelopmentFundSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		//Required fields
		subject.ReferenceIdentification = "3";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		//Required fields
		subject.TransactionHandlingCode = "a";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
