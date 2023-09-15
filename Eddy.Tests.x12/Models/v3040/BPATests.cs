using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPA*9q*oeBjbB*9e*U*Ne4B";

		var expected = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus()
		{
			TransactionSetPurposeCode = "9q",
			Date = "oeBjbB",
			ReferenceNumberQualifier = "9e",
			ReferenceNumber = "U",
			Time = "Ne4B",
		};

		var actual = Map.MapObject<BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9q", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.Date = "oeBjbB";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "9e";
			subject.ReferenceNumber = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oeBjbB", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "9q";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "9e";
			subject.ReferenceNumber = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9e", "U", true)]
	[InlineData("9e", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "9q";
		subject.Date = "oeBjbB";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
