using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BQRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQR*ZO*V*rstV2xye*Wdd*vZGmQm70*Ox*DK*O";

		var expected = new BQR_BeginningSegmentForResponseToRequestForQuotation()
		{
			TransactionSetPurposeCode = "ZO",
			RequestForQuoteReferenceNumber = "V",
			Date = "rstV2xye",
			DateTimeQualifier = "Wdd",
			Date2 = "vZGmQm70",
			BidTypeResponseCode = "Ox",
			SecurityLevelCode = "DK",
			ChangeOrderSequenceNumber = "O",
		};

		var actual = Map.MapObject<BQR_BeginningSegmentForResponseToRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZO", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "V";
		subject.Date = "rstV2xye";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validatation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "ZO";
		subject.Date = "rstV2xye";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rstV2xye", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "ZO";
		subject.RequestForQuoteReferenceNumber = "V";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Wdd", "vZGmQm70", true)]
	[InlineData("", "vZGmQm70", false)]
	[InlineData("Wdd", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date2, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "ZO";
		subject.RequestForQuoteReferenceNumber = "V";
		subject.Date = "rstV2xye";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
