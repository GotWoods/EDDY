using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BQTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BQT*B6*R*qtskuUN6*BqL*mVCZWVi1*T4*dP*1K*Wg*Wc*W";

		var expected = new BQT_BeginningSegmentForRequestForQuotation()
		{
			TransactionSetPurposeCode = "B6",
			RequestForQuoteReferenceNumber = "R",
			Date = "qtskuUN6",
			DateTimeQualifier = "BqL",
			Date2 = "mVCZWVi1",
			PurchaseOrderTypeCode = "T4",
			RequestForQuoteTypeCode = "dP",
			ContractTypeCode = "1K",
			SecurityLevelCode = "Wg",
			PurchaseCategoryCode = "Wc",
			ChangeOrderSequenceNumber = "W",
		};

		var actual = Map.MapObject<BQT_BeginningSegmentForRequestForQuotation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B6", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.RequestForQuoteReferenceNumber = "R";
		subject.Date = "qtskuUN6";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "BqL";
			subject.Date2 = "mVCZWVi1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredRequestForQuoteReferenceNumber(string requestForQuoteReferenceNumber, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "B6";
		subject.Date = "qtskuUN6";
		subject.RequestForQuoteReferenceNumber = requestForQuoteReferenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "BqL";
			subject.Date2 = "mVCZWVi1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qtskuUN6", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "B6";
		subject.RequestForQuoteReferenceNumber = "R";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier = "BqL";
			subject.Date2 = "mVCZWVi1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BqL", "mVCZWVi1", true)]
	[InlineData("BqL", "", false)]
	[InlineData("", "mVCZWVi1", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date2, bool isValidExpected)
	{
		var subject = new BQT_BeginningSegmentForRequestForQuotation();
		subject.TransactionSetPurposeCode = "B6";
		subject.RequestForQuoteReferenceNumber = "R";
		subject.Date = "qtskuUN6";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
