using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OTI*9*x7*b*dJ*rM*aPUxRm*xx2t*2*uWpg*urA*2";

		var expected = new OTI_OriginalTransactionIdentification()
		{
			ApplicationAcknowledgmentCode = "9",
			ReferenceNumberQualifier = "x7",
			ReferenceNumber = "b",
			ApplicationSendersCode = "dJ",
			ApplicationReceiversCode = "rM",
			Date = "aPUxRm",
			Time = "xx2t",
			GroupControlNumber = 2,
			TransactionSetControlNumber = "uWpg",
			TransactionSetIdentifierCode = "urA",
			VersionReleaseIndustryIdentifierCode = "2",
		};

		var actual = Map.MapObject<OTI_OriginalTransactionIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredApplicationAcknowledgmentCode(string applicationAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ReferenceNumberQualifier = "x7";
		subject.ReferenceNumber = "b";
		subject.ApplicationAcknowledgmentCode = applicationAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x7", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "9";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "9";
		subject.ReferenceNumberQualifier = "x7";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("uWpg", 2, true)]
	[InlineData("uWpg", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBTransactionSetControlNumber(string transactionSetControlNumber, int groupControlNumber, bool isValidExpected)
	{
		var subject = new OTI_OriginalTransactionIdentification();
		subject.ApplicationAcknowledgmentCode = "9";
		subject.ReferenceNumberQualifier = "x7";
		subject.ReferenceNumber = "b";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
