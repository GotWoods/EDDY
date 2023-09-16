using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OTI*0*Lw*Q*xk*Mc*Z9AHdIfo*sHKU*9*ESnz*se1*P*eN*5d*ce*8*U*UnB";

		var expected = new OTI_OriginalTransactionIdentification()
		{
			ApplicationAcknowledgmentCode = "0",
			ReferenceIdentificationQualifier = "Lw",
			ReferenceIdentification = "Q",
			ApplicationSendersCode = "xk",
			ApplicationReceiversCode = "Mc",
			Date = "Z9AHdIfo",
			Time = "sHKU",
			GroupControlNumber = 9,
			TransactionSetControlNumber = "ESnz",
			TransactionSetIdentifierCode = "se1",
			VersionReleaseIndustryIdentifierCode = "P",
			TransactionSetPurposeCode = "eN",
			TransactionTypeCode = "5d",
			ApplicationType = "ce",
			ActionCode = "8",
			TransactionHandlingCode = "U",
			StatusReasonCode = "UnB",
		};

		var actual = Map.MapObject<OTI_OriginalTransactionIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredApplicationAcknowledgmentCode(string applicationAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ReferenceIdentificationQualifier = "Lw";
		subject.ReferenceIdentification = "Q";
		subject.ApplicationAcknowledgmentCode = applicationAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lw", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "0";
		subject.ReferenceIdentification = "Q";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "0";
		subject.ReferenceIdentificationQualifier = "Lw";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ESnz", 9, true)]
	[InlineData("ESnz", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBTransactionSetControlNumber(string transactionSetControlNumber, int groupControlNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "0";
		subject.ReferenceIdentificationQualifier = "Lw";
		subject.ReferenceIdentification = "Q";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
