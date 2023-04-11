using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OTI*h*aT*X*yV*UX*r5wSL3dx*bg0t*9*XrDS*wjS*R*pC*HE*K8*8*f*4Mo";

		var expected = new OTI_OriginalTransactionIdentification()
		{
			ApplicationAcknowledgmentCode = "h",
			ReferenceIdentificationQualifier = "aT",
			ReferenceIdentification = "X",
			ApplicationSendersCode = "yV",
			ApplicationReceiversCode = "UX",
			Date = "r5wSL3dx",
			Time = "bg0t",
			GroupControlNumber = 9,
			TransactionSetControlNumber = "XrDS",
			TransactionSetIdentifierCode = "wjS",
			VersionReleaseIndustryIdentifierCode = "R",
			TransactionSetPurposeCode = "pC",
			TransactionTypeCode = "HE",
			ApplicationTypeCode = "K8",
			ActionCode = "8",
			TransactionHandlingCode = "f",
			StatusReasonCode = "4Mo",
		};

		var actual = Map.MapObject<OTI_OriginalTransactionIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredApplicationAcknowledgmentCode(string applicationAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ReferenceIdentificationQualifier = "aT";
		subject.ReferenceIdentification = "X";
		subject.ApplicationAcknowledgmentCode = applicationAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aT", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "h";
		subject.ReferenceIdentification = "X";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "h";
		subject.ReferenceIdentificationQualifier = "aT";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 9, true)]
	[InlineData("XrDS", 0, false)]
	public void Validation_ARequiresBTransactionSetControlNumber(string transactionSetControlNumber, int groupControlNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "h";
		subject.ReferenceIdentificationQualifier = "aT";
		subject.ReferenceIdentification = "X";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		if (groupControlNumber > 0)
		subject.GroupControlNumber = groupControlNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
