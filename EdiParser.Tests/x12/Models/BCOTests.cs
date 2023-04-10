using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*NZ*t*ixOeP4KT*U*YN*jNZ6j8ay*lSeaI13O*uO*qc*t*2l*L";

		var expected = new BCO_BeginningSegmentForProcurementNotices()
		{
			TransactionSetPurposeCode = "NZ",
			RequestForQuoteReferenceNumber = "t",
			Date = "ixOeP4KT",
			ReferenceIdentification = "U",
			ContractStatusCode = "YN",
			Date2 = "jNZ6j8ay",
			Date3 = "lSeaI13O",
			AcknowledgmentTypeCode = "uO",
			ReferenceIdentificationQualifier = "qc",
			ReferenceIdentification2 = "t",
			TransactionTypeCode = "2l",
			ActionCode = "L",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForProcurementNotices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NZ", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("qc", "t", true)]
	[InlineData("", "t", false)]
	[InlineData("qc", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = "NZ";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
