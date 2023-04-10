using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BQTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQT*3O*v*FujpQVN2*dXI*AX1TVjzP*PB*b8*nG*N0*7y*q";

		var expected = new BQT_BeginningSegmentForRequestForQuotation()
		{
			TransactionSetPurposeCode = "3O",
			RequestForQuoteReferenceNumber = "v",
			Date = "FujpQVN2",
			DateTimeQualifier = "dXI",
			Date2 = "AX1TVjzP",
			PurchaseOrderTypeCode = "PB",
			RequestForQuoteTypeCode = "b8",
			ContractTypeCode = "nG",
			SecurityLevelCode = "N0",
			PurchaseCategoryCode = "7y",
			ChangeOrderSequenceNumber = "q",
		};

		var actual = Map.MapObject<BQT_BeginningSegmentForRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3O", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "v";
		subject.Date = "FujpQVN2";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validatation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "3O";
		subject.Date = "FujpQVN2";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FujpQVN2", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "3O";
		subject.RequestForQuoteReferenceNumber = "v";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("dXI", "AX1TVjzP", true)]
	[InlineData("", "AX1TVjzP", false)]
	[InlineData("dXI", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date2, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "3O";
		subject.RequestForQuoteReferenceNumber = "v";
		subject.Date = "FujpQVN2";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
