using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*ey*S*yI36Jc5a*y*Im*5ZWV4DoI*4QsSRY0V*80*11*f*UT*4";

		var expected = new BCO_BeginningSegmentForProcurementNotices()
		{
			TransactionSetPurposeCode = "ey",
			RequestForQuoteReferenceNumber = "S",
			Date = "yI36Jc5a",
			ReferenceIdentification = "y",
			ContractStatusCode = "Im",
			Date2 = "5ZWV4DoI",
			Date3 = "4QsSRY0V",
			AcknowledgmentType = "80",
			ReferenceIdentificationQualifier = "11",
			ReferenceIdentification2 = "f",
			TransactionTypeCode = "UT",
			ActionCode = "4",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForProcurementNotices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ey", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "11";
			subject.ReferenceIdentification2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("11", "f", true)]
	[InlineData("11", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = "ey";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
