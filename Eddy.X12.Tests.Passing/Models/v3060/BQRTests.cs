using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BQRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQR*5q*A*Ynr4DZ*Bj3*nBY9e5*hM*86*O";

		var expected = new BQR_BeginningSegmentForResponseToRequestForQuotation()
		{
			TransactionSetPurposeCode = "5q",
			RequestForQuoteReferenceNumber = "A",
			Date = "Ynr4DZ",
			DateTimeQualifier = "Bj3",
			Date2 = "nBY9e5",
			BidTypeResponseCode = "hM",
			SecurityLevelCode = "86",
			ChangeOrderSequenceNumber = "O",
		};

		var actual = Map.MapObject<BQR_BeginningSegmentForResponseToRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5q", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "A";
		subject.Date = "Ynr4DZ";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "Bj3";
			subject.Date2 = "nBY9e5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "5q";
		subject.Date = "Ynr4DZ";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "Bj3";
			subject.Date2 = "nBY9e5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ynr4DZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "5q";
		subject.RequestForQuoteReferenceNumber = "A";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "Bj3";
			subject.Date2 = "nBY9e5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bj3", "nBY9e5", true)]
	[InlineData("Bj3", "", false)]
	[InlineData("", "nBY9e5", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date2, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "5q";
		subject.RequestForQuoteReferenceNumber = "A";
		subject.Date = "Ynr4DZ";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
