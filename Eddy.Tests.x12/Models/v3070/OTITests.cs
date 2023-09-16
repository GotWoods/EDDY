using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OTI*7*6s*Z*AN*mB*2COOjj*78vv*3*DlSJ*jrx*0*41*Hm*wa*y*1*MFS";

		var expected = new OTI_OriginalTransactionIdentification()
		{
			ApplicationAcknowledgmentCode = "7",
			ReferenceIdentificationQualifier = "6s",
			ReferenceIdentification = "Z",
			ApplicationSendersCode = "AN",
			ApplicationReceiversCode = "mB",
			Date = "2COOjj",
			Time = "78vv",
			GroupControlNumber = 3,
			TransactionSetControlNumber = "DlSJ",
			TransactionSetIdentifierCode = "jrx",
			VersionReleaseIndustryIdentifierCode = "0",
			TransactionSetPurposeCode = "41",
			TransactionTypeCode = "Hm",
			ApplicationType = "wa",
			ActionCode = "y",
			TransactionHandlingCode = "1",
			StatusReasonCode = "MFS",
		};

		var actual = Map.MapObject<OTI_OriginalTransactionIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredApplicationAcknowledgmentCode(string applicationAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ReferenceIdentificationQualifier = "6s";
		subject.ReferenceIdentification = "Z";
		subject.ApplicationAcknowledgmentCode = applicationAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6s", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "7";
		subject.ReferenceIdentification = "Z";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "7";
		subject.ReferenceIdentificationQualifier = "6s";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("DlSJ", 3, true)]
	[InlineData("DlSJ", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBTransactionSetControlNumber(string transactionSetControlNumber, int groupControlNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "7";
		subject.ReferenceIdentificationQualifier = "6s";
		subject.ReferenceIdentification = "Z";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
