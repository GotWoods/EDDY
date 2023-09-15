using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BQTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQT*A3*k*PFFYV0zE*MmJ*HYFKFtsN*tm*Sp*Ew*q2*7r*q";

		var expected = new BQT_BeginningSegmentForRequestForQuotation()
		{
			TransactionSetPurposeCode = "A3",
			RequestForQuoteReferenceNumber = "k",
			Date = "PFFYV0zE",
			DateTimeQualifier = "MmJ",
			Date2 = "HYFKFtsN",
			PurchaseOrderTypeCode = "tm",
			RequestForQuoteTypeCode = "Sp",
			ContractTypeCode = "Ew",
			SecurityLevelCode = "q2",
			PurchaseCategory = "7r",
			ChangeOrderSequenceNumber = "q",
		};

		var actual = Map.MapObject<BQT_BeginningSegmentForRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A3", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "k";
		subject.Date = "PFFYV0zE";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "MmJ";
			subject.Date2 = "HYFKFtsN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "A3";
		subject.Date = "PFFYV0zE";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "MmJ";
			subject.Date2 = "HYFKFtsN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PFFYV0zE", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "A3";
		subject.RequestForQuoteReferenceNumber = "k";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "MmJ";
			subject.Date2 = "HYFKFtsN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MmJ", "HYFKFtsN", true)]
	[InlineData("MmJ", "", false)]
	[InlineData("", "HYFKFtsN", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date2, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "A3";
		subject.RequestForQuoteReferenceNumber = "k";
		subject.Date = "PFFYV0zE";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
