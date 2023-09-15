using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BQRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQR*d3*F*hQ9blZ*7jp*LCmgo3*WJ";

		var expected = new BQR_BeginningSegmentForResponseToRequestForQuotation()
		{
			TransactionSetPurposeCode = "d3",
			RequestForQuoteReferenceNumber = "F",
			RequestQuotationControlDate = "hQ9blZ",
			DateTimeQualifier = "7jp",
			Date = "LCmgo3",
			BidTypeResponseCode = "WJ",
		};

		var actual = Map.MapObject<BQR_BeginningSegmentForResponseToRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d3", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "F";
		subject.RequestQuotationControlDate = "hQ9blZ";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "d3";
		subject.RequestQuotationControlDate = "hQ9blZ";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hQ9blZ", true)]
	public void Validation_RequiredRequestQuotationControlDate(string requestQuotationControlDate, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "d3";
		subject.RequestForQuoteReferenceNumber = "F";
		subject.RequestQuotationControlDate = requestQuotationControlDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
