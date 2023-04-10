using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPA*fv*PT2cKlku*ah*c*2fWL";

		var expected = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus()
		{
			TransactionSetPurposeCode = "fv",
			Date = "PT2cKlku",
			ReferenceIdentificationQualifier = "ah",
			ReferenceIdentification = "c",
			Time = "2fWL",
		};

		var actual = Map.MapObject<BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fv", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.Date = "PT2cKlku";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PT2cKlku", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "fv";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ah", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("ah", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BPA_BeginningSegmentForPriceAuthorizationAcknowledgmentStatus();
		subject.TransactionSetPurposeCode = "fv";
		subject.Date = "PT2cKlku";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
