using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTP*UP*J*6TJGl8*yMgF*7Q*LS*6*5AXiFg*Lveu";

		var expected = new BTP_BeginningSegmentForTradingPartnerProfile()
		{
			TransactionSetPurposeCode = "UP",
			ReferenceNumber = "J",
			Date = "6TJGl8",
			Time = "yMgF",
			TransactionTypeCode = "7Q",
			TransactionSetPurposeCode2 = "LS",
			ReferenceNumber2 = "6",
			Date2 = "5AXiFg",
			Time2 = "Lveu",
		};

		var actual = Map.MapObject<BTP_BeginningSegmentForTradingPartnerProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UP", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.ReferenceNumber = "J";
		subject.Date = "6TJGl8";
		subject.Time = "yMgF";
		subject.TransactionTypeCode = "7Q";
		subject.TransactionSetPurposeCode2 = "LS";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "UP";
		subject.Date = "6TJGl8";
		subject.Time = "yMgF";
		subject.TransactionTypeCode = "7Q";
		subject.TransactionSetPurposeCode2 = "LS";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6TJGl8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "UP";
		subject.ReferenceNumber = "J";
		subject.Time = "yMgF";
		subject.TransactionTypeCode = "7Q";
		subject.TransactionSetPurposeCode2 = "LS";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yMgF", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "UP";
		subject.ReferenceNumber = "J";
		subject.Date = "6TJGl8";
		subject.TransactionTypeCode = "7Q";
		subject.TransactionSetPurposeCode2 = "LS";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7Q", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "UP";
		subject.ReferenceNumber = "J";
		subject.Date = "6TJGl8";
		subject.Time = "yMgF";
		subject.TransactionSetPurposeCode2 = "LS";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LS", true)]
	public void Validation_RequiredTransactionSetPurposeCode2(string transactionSetPurposeCode2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "UP";
		subject.ReferenceNumber = "J";
		subject.Date = "6TJGl8";
		subject.Time = "yMgF";
		subject.TransactionTypeCode = "7Q";
		//Test Parameters
		subject.TransactionSetPurposeCode2 = transactionSetPurposeCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5AXiFg", "6", true)]
	[InlineData("5AXiFg", "", false)]
	[InlineData("", "6", true)]
	public void Validation_ARequiresBDate2(string date2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "UP";
		subject.ReferenceNumber = "J";
		subject.Date = "6TJGl8";
		subject.Time = "yMgF";
		subject.TransactionTypeCode = "7Q";
		subject.TransactionSetPurposeCode2 = "LS";
		//Test Parameters
		subject.Date2 = date2;
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lveu", "5AXiFg", true)]
	[InlineData("Lveu", "", false)]
	[InlineData("", "5AXiFg", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "UP";
		subject.ReferenceNumber = "J";
		subject.Date = "6TJGl8";
		subject.Time = "yMgF";
		subject.TransactionTypeCode = "7Q";
		subject.TransactionSetPurposeCode2 = "LS";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;
		//A Requires B
		if (date2 != "")
			subject.ReferenceNumber2 = "6";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
