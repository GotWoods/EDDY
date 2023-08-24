using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*ZD*f*2De64X*c*9y*Ph157f*Za6kDm*C9";

		var expected = new BCO_BeginningSegmentForContractAward()
		{
			TransactionSetPurposeCode = "ZD",
			RequestForQuoteReferenceNumber = "f",
			RequestQuotationControlDate = "2De64X",
			ReferenceNumber = "c",
			ContractStatusCode = "9y",
			Date = "Ph157f",
			Date2 = "Za6kDm",
			AcknowledgmentType = "C9",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForContractAward>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZD", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.RequestForQuoteReferenceNumber = "f";
		subject.RequestQuotationControlDate = "2De64X";
		subject.ReferenceNumber = "c";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "ZD";
		subject.RequestQuotationControlDate = "2De64X";
		subject.ReferenceNumber = "c";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2De64X", true)]
	public void Validation_RequiredRequestQuotationControlDate(string requestQuotationControlDate, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "ZD";
		subject.RequestForQuoteReferenceNumber = "f";
		subject.ReferenceNumber = "c";
		subject.RequestQuotationControlDate = requestQuotationControlDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "ZD";
		subject.RequestForQuoteReferenceNumber = "f";
		subject.RequestQuotationControlDate = "2De64X";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
