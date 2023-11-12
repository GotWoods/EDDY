using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTP*gp*9*TqzCDn*0nVz*89*Ph*u*GbCGvQ*YLqg*6Tj";

		var expected = new BTP_BeginningSegmentForTradingPartnerProfile()
		{
			TransactionSetPurposeCode = "gp",
			ReferenceNumber = "9",
			Date = "TqzCDn",
			Time = "0nVz",
			TransactionTypeCode = "89",
			TransactionSetPurposeCode2 = "Ph",
			ReferenceNumber2 = "u",
			Date2 = "GbCGvQ",
			Time2 = "YLqg",
			PaymentMethodCode = "6Tj",
		};

		var actual = Map.MapObject<BTP_BeginningSegmentForTradingPartnerProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gp", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.ReferenceNumber = "9";
		subject.Date = "TqzCDn";
		subject.Time = "0nVz";
		subject.TransactionTypeCode = "89";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "gp";
		subject.Date = "TqzCDn";
		subject.Time = "0nVz";
		subject.TransactionTypeCode = "89";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TqzCDn", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "gp";
		subject.ReferenceNumber = "9";
		subject.Time = "0nVz";
		subject.TransactionTypeCode = "89";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0nVz", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "gp";
		subject.ReferenceNumber = "9";
		subject.Date = "TqzCDn";
		subject.TransactionTypeCode = "89";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("89", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "gp";
		subject.ReferenceNumber = "9";
		subject.Date = "TqzCDn";
		subject.Time = "0nVz";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GbCGvQ", "u", true)]
	[InlineData("GbCGvQ", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBDate2(string date2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "gp";
		subject.ReferenceNumber = "9";
		subject.Date = "TqzCDn";
		subject.Time = "0nVz";
		subject.TransactionTypeCode = "89";
		//Test Parameters
		subject.Date2 = date2;
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YLqg", "GbCGvQ", true)]
	[InlineData("YLqg", "", false)]
	[InlineData("", "GbCGvQ", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "gp";
		subject.ReferenceNumber = "9";
		subject.Date = "TqzCDn";
		subject.Time = "0nVz";
		subject.TransactionTypeCode = "89";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;
		//A Requires B
		if (date2 != "")
			subject.ReferenceNumber2 = "u";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
