using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*qV*1*bS2m6l*Z*mH*HbMcpH*5dTqix*Lb*8N*p";

		var expected = new BCO_BeginningSegmentForContractAward()
		{
			TransactionSetPurposeCode = "qV",
			RequestForQuoteReferenceNumber = "1",
			RequestQuotationControlDate = "bS2m6l",
			ReferenceNumber = "Z",
			ContractStatusCode = "mH",
			Date = "HbMcpH",
			Date2 = "5dTqix",
			AcknowledgmentType = "Lb",
			ReferenceNumberQualifier = "8N",
			ReferenceNumber2 = "p",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForContractAward>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qV", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.RequestForQuoteReferenceNumber = "1";
		subject.RequestQuotationControlDate = "bS2m6l";
		subject.ReferenceNumber = "Z";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "qV";
		subject.RequestQuotationControlDate = "bS2m6l";
		subject.ReferenceNumber = "Z";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bS2m6l", true)]
	public void Validation_RequiredRequestQuotationControlDate(string requestQuotationControlDate, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "qV";
		subject.RequestForQuoteReferenceNumber = "1";
		subject.ReferenceNumber = "Z";
		subject.RequestQuotationControlDate = requestQuotationControlDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "qV";
		subject.RequestForQuoteReferenceNumber = "1";
		subject.RequestQuotationControlDate = "bS2m6l";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
