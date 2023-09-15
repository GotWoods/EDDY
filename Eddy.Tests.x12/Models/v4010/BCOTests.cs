using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*zW*q*ES7DM4pe*f*Wv*d8vDVxY3*eXutiJxB*sY*SW*r*6D*y";

		var expected = new BCO_BeginningSegmentForProcurementNotices()
		{
			TransactionSetPurposeCode = "zW",
			RequestForQuoteReferenceNumber = "q",
			Date = "ES7DM4pe",
			ReferenceIdentification = "f",
			ContractStatusCode = "Wv",
			Date2 = "d8vDVxY3",
			Date3 = "eXutiJxB",
			AcknowledgmentType = "sY",
			ReferenceIdentificationQualifier = "SW",
			ReferenceIdentification2 = "r",
			TransactionTypeCode = "6D",
			ActionCode = "y",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForProcurementNotices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zW", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "SW";
			subject.ReferenceIdentification2 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SW", "r", true)]
	[InlineData("SW", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = "zW";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
