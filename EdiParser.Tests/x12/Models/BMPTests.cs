using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMP*U*k*OSA*M";

		var expected = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement()
		{
			TransactionHandlingCode = "U",
			ReferenceIdentification = "k",
			PaymentMethodCode = "OSA",
			ReferenceIdentification2 = "M",
		};

		var actual = Map.MapObject<BMP_BeginningSegmentForMarketDevelopmentFundSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validatation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		subject.ReferenceIdentification = "k";
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMP_BeginningSegmentForMarketDevelopmentFundSettlement();
		subject.TransactionHandlingCode = "U";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
