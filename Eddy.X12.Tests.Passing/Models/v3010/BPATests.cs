using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPA*PQ*51NAIm*uz*v*Kbbz";

		var expected = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus()
		{
			TransactionSetPurposeCode = "PQ",
			Date = "51NAIm",
			ReferenceNumberQualifier = "uz",
			ReferenceNumber = "v",
			Time = "Kbbz",
		};

		var actual = Map.MapObject<BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PQ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.Date = "51NAIm";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("51NAIm", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "PQ";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
