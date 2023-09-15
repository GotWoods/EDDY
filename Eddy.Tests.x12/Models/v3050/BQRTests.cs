using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BQRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQR*3c*2*xCuLGV*ChX*VtI5sA*7S*hM";

		var expected = new BQR_BeginningSegmentForResponseToRequestForQuotation()
		{
			TransactionSetPurposeCode = "3c",
			RequestForQuoteReferenceNumber = "2",
			Date = "xCuLGV",
			DateTimeQualifier = "ChX",
			Date2 = "VtI5sA",
			BidTypeResponseCode = "7S",
			SecurityLevelCode = "hM",
		};

		var actual = Map.MapObject<BQR_BeginningSegmentForResponseToRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3c", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "2";
		subject.Date = "xCuLGV";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "ChX";
			subject.Date2 = "VtI5sA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "3c";
		subject.Date = "xCuLGV";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "ChX";
			subject.Date2 = "VtI5sA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xCuLGV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "3c";
		subject.RequestForQuoteReferenceNumber = "2";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "ChX";
			subject.Date2 = "VtI5sA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ChX", "VtI5sA", true)]
	[InlineData("ChX", "", false)]
	[InlineData("", "VtI5sA", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date2, bool isValidExpected)
	{
		var subject = new BQR_BeginningSegmentForResponseToRequestForQuotation();
		subject.TransactionSetPurposeCode = "3c";
		subject.RequestForQuoteReferenceNumber = "2";
		subject.Date = "xCuLGV";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
