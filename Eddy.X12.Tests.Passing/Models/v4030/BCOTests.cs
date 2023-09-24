using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*E1*O*RPW2iiZe*B*kB*U7uuQBDD*E3xlmGWL*1W*fu*Y*Cj*9";

		var expected = new BCO_BeginningSegmentForProcurementNotices()
		{
			TransactionSetPurposeCode = "E1",
			RequestForQuoteReferenceNumber = "O",
			Date = "RPW2iiZe",
			ReferenceIdentification = "B",
			ContractStatusCode = "kB",
			Date2 = "U7uuQBDD",
			Date3 = "E3xlmGWL",
			AcknowledgmentType = "1W",
			ReferenceIdentificationQualifier = "fu",
			ReferenceIdentification2 = "Y",
			TransactionTypeCode = "Cj",
			ActionCode = "9",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForProcurementNotices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E1", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "fu";
			subject.ReferenceIdentification2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fu", "Y", true)]
	[InlineData("fu", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = "E1";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
