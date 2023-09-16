using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OTI*e*yV*S*bC*xN*AV3Wwq*koVm*7*jSQQ*9hA*4";

		var expected = new OTI_OriginalTransactionIdentification()
		{
			ApplicationAcknowledgmentCode = "e",
			ReferenceNumberQualifier = "yV",
			ReferenceNumber = "S",
			ApplicationSendersCode = "bC",
			ApplicationReceiversCode = "xN",
			GroupDate = "AV3Wwq",
			GroupTime = "koVm",
			GroupControlNumber = 7,
			TransactionSetControlNumber = "jSQQ",
			TransactionSetIdentifierCode = "9hA",
			VersionReleaseIndustryIdentifierCode = "4",
		};

		var actual = Map.MapObject<OTI_OriginalTransactionIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredApplicationAcknowledgmentCode(string applicationAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ReferenceNumberQualifier = "yV";
		subject.ReferenceNumber = "S";
		subject.ApplicationAcknowledgmentCode = applicationAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yV", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "e";
		subject.ReferenceNumber = "S";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "e";
		subject.ReferenceNumberQualifier = "yV";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
