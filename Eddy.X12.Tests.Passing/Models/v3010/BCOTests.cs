using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*dE*1*6vxaAm*I*EF*h6nDbj*adrOHX*mz";

		var expected = new BCO_BeginningSegmentForContractAward()
		{
			TransactionSetPurposeCode = "dE",
			RequestForQuoteReferenceNumber = "1",
			RequestQuotationControlDate = "6vxaAm",
			ReferenceNumber = "I",
			ContractStatusCode = "EF",
			Date = "h6nDbj",
			Date2 = "adrOHX",
			AcknowledgmentType = "mz",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForContractAward>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dE", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.RequestForQuoteReferenceNumber = "1";
		subject.RequestQuotationControlDate = "6vxaAm";
		subject.ReferenceNumber = "I";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "dE";
		subject.RequestQuotationControlDate = "6vxaAm";
		subject.ReferenceNumber = "I";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6vxaAm", true)]
	public void Validation_RequiredRequestQuotationControlDate(string requestQuotationControlDate, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "dE";
		subject.RequestForQuoteReferenceNumber = "1";
		subject.ReferenceNumber = "I";
		subject.RequestQuotationControlDate = requestQuotationControlDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForContractAward();
		subject.TransactionSetPurposeCode = "dE";
		subject.RequestForQuoteReferenceNumber = "1";
		subject.RequestQuotationControlDate = "6vxaAm";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
