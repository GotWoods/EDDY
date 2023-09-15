using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BQRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQR*iF*4*0cmLrn*aBq*TPRE20*3e";

		var expected = new BQR_BeginningSegmentForResponseToRequestForQuotation()
		{
			TransactionSetPurposeCode = "iF",
			RequestForQuoteReferenceNumber = "4",
			RequestQuotationControlDate = "0cmLrn",
			DateTimeQualifier = "aBq",
			Date = "TPRE20",
			BidTypeResponseCode = "3e",
		};

		var actual = Map.MapObject<BQR_BeginningSegmentForResponseToRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iF", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "4";
		subject.RequestQuotationControlDate = "0cmLrn";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "iF";
		subject.RequestQuotationControlDate = "0cmLrn";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0cmLrn", true)]
	public void Validation_RequiredRequestQuotationControlDate(string requestQuotationControlDate, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "iF";
		subject.RequestForQuoteReferenceNumber = "4";
		subject.RequestQuotationControlDate = requestQuotationControlDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TPRE20", "aBq", true)]
	[InlineData("TPRE20", "", false)]
	[InlineData("", "aBq", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "iF";
		subject.RequestForQuoteReferenceNumber = "4";
		subject.RequestQuotationControlDate = "0cmLrn";
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
