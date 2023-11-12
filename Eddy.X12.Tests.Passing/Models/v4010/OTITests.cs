using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OTI*v*cp*N*4y*X9*5dMcyIxL*qVii*1*SKWZ*Ivv*Z*wa*uv*ma*a*B*Soh";

		var expected = new OTI_OriginalTransactionIdentification()
		{
			ApplicationAcknowledgmentCode = "v",
			ReferenceIdentificationQualifier = "cp",
			ReferenceIdentification = "N",
			ApplicationSendersCode = "4y",
			ApplicationReceiversCode = "X9",
			Date = "5dMcyIxL",
			Time = "qVii",
			GroupControlNumber = 1,
			TransactionSetControlNumber = "SKWZ",
			TransactionSetIdentifierCode = "Ivv",
			VersionReleaseIndustryIdentifierCode = "Z",
			TransactionSetPurposeCode = "wa",
			TransactionTypeCode = "uv",
			ApplicationType = "ma",
			ActionCode = "a",
			TransactionHandlingCode = "B",
			StatusReasonCode = "Soh",
		};

		var actual = Map.MapObject<OTI_OriginalTransactionIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredApplicationAcknowledgmentCode(string applicationAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ReferenceIdentificationQualifier = "cp";
		subject.ReferenceIdentification = "N";
		subject.ApplicationAcknowledgmentCode = applicationAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cp", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "v";
		subject.ReferenceIdentification = "N";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "v";
		subject.ReferenceIdentificationQualifier = "cp";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("SKWZ", 1, true)]
	[InlineData("SKWZ", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBTransactionSetControlNumber(string transactionSetControlNumber, int groupControlNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "v";
		subject.ReferenceIdentificationQualifier = "cp";
		subject.ReferenceIdentification = "N";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
