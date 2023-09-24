using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BQTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQT*vE*Y*l0oCqj*mGW*ZsNSC4*ch*OG";

		var expected = new BQT_BeginningSegmentForRequestForQuotation()
		{
			TransactionSetPurposeCode = "vE",
			RequestForQuoteReferenceNumber = "Y",
			RequestQuotationControlDate = "l0oCqj",
			DateTimeQualifier = "mGW",
			Date = "ZsNSC4",
			PurchaseOrderTypeCode = "ch",
			RequestForQuoteTypeCode = "OG",
		};

		var actual = Map.MapObject<BQT_BeginningSegmentForRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vE", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "Y";
		subject.RequestQuotationControlDate = "l0oCqj";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "vE";
		subject.RequestQuotationControlDate = "l0oCqj";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l0oCqj", true)]
	public void Validation_RequiredRequestQuotationControlDate(string requestQuotationControlDate, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "vE";
		subject.RequestForQuoteReferenceNumber = "Y";
		subject.RequestQuotationControlDate = requestQuotationControlDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
