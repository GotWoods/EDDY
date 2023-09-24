using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OTI*s*3n*M*Ur*fS*rbvrlxbK*gltO*2*uMXU*yJZ*w*Uv*2r*kI*w*U*P96";

		var expected = new OTI_OriginalTransactionIdentification()
		{
			ApplicationAcknowledgmentCode = "s",
			ReferenceIdentificationQualifier = "3n",
			ReferenceIdentification = "M",
			ApplicationSendersCode = "Ur",
			ApplicationReceiversCode = "fS",
			Date = "rbvrlxbK",
			Time = "gltO",
			GroupControlNumber = 2,
			TransactionSetControlNumber = "uMXU",
			TransactionSetIdentifierCode = "yJZ",
			VersionReleaseIndustryIdentifierCode = "w",
			TransactionSetPurposeCode = "Uv",
			TransactionTypeCode = "2r",
			ApplicationTypeCode = "kI",
			ActionCode = "w",
			TransactionHandlingCode = "U",
			StatusReasonCode = "P96",
		};

		var actual = Map.MapObject<OTI_OriginalTransactionIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredApplicationAcknowledgmentCode(string applicationAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ReferenceIdentificationQualifier = "3n";
		subject.ReferenceIdentification = "M";
		subject.ApplicationAcknowledgmentCode = applicationAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3n", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "s";
		subject.ReferenceIdentification = "M";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "s";
		subject.ReferenceIdentificationQualifier = "3n";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("uMXU", 2, true)]
	[InlineData("uMXU", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBTransactionSetControlNumber(string transactionSetControlNumber, int groupControlNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "s";
		subject.ReferenceIdentificationQualifier = "3n";
		subject.ReferenceIdentification = "M";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
