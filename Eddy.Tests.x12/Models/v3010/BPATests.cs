using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPA*2x*997vqh*ze*f*8tgC";

		var expected = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus()
		{
			TransactionSetPurposeCode = "2x",
			Date = "997vqh",
			ReferenceNumberQualifier = "ze",
			ReferenceNumber = "f",
			Time = "8tgC",
		};

		var actual = Map.MapObject<BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2x", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.Date = "997vqh";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("997vqh", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "2x";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
