using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BQTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQT*mW*C*IT0tIB*HlQ*jFPupD*qJ*GR*If*Ku*sN";

		var expected = new BQT_BeginningSegmentForRequestForQuotation()
		{
			TransactionSetPurposeCode = "mW",
			RequestForQuoteReferenceNumber = "C",
			Date = "IT0tIB",
			DateTimeQualifier = "HlQ",
			Date2 = "jFPupD",
			PurchaseOrderTypeCode = "qJ",
			RequestForQuoteTypeCode = "GR",
			ContractTypeCode = "If",
			SecurityLevelCode = "Ku",
			PurchaseCategory = "sN",
		};

		var actual = Map.MapObject<BQT_BeginningSegmentForRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mW", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "C";
		subject.Date = "IT0tIB";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "HlQ";
			subject.Date2 = "jFPupD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "mW";
		subject.Date = "IT0tIB";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "HlQ";
			subject.Date2 = "jFPupD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IT0tIB", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "mW";
		subject.RequestForQuoteReferenceNumber = "C";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "HlQ";
			subject.Date2 = "jFPupD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HlQ", "jFPupD", true)]
	[InlineData("HlQ", "", false)]
	[InlineData("", "jFPupD", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date2, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "mW";
		subject.RequestForQuoteReferenceNumber = "C";
		subject.Date = "IT0tIB";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
