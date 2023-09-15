using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPA*oY*BhF6HEWw*SW*D*b6JQ";

		var expected = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus()
		{
			TransactionSetPurposeCode = "oY",
			Date = "BhF6HEWw",
			ReferenceIdentificationQualifier = "SW",
			ReferenceIdentification = "D",
			Time = "b6JQ",
		};

		var actual = Map.MapObject<BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oY", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.Date = "BhF6HEWw";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "SW";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BhF6HEWw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "oY";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "SW";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SW", "D", true)]
	[InlineData("SW", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "oY";
		subject.Date = "BhF6HEWw";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
