using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTP*2t*9*81ZyTc8G*YxTq*lT*dL*w*LEBIgOqq*u2CZ*jV8";

		var expected = new BTP_BeginningSegmentForTradingPartnerProfile()
		{
			TransactionSetPurposeCode = "2t",
			ReferenceIdentification = "9",
			Date = "81ZyTc8G",
			Time = "YxTq",
			TransactionTypeCode = "lT",
			TransactionSetPurposeCode2 = "dL",
			ReferenceIdentification2 = "w",
			Date2 = "LEBIgOqq",
			Time2 = "u2CZ",
			PaymentMethodCode = "jV8",
		};

		var actual = Map.MapObject<BTP_BeginningSegmentForTradingPartnerProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("2t", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		subject.ReferenceIdentification = "9";
		subject.Date = "81ZyTc8G";
		subject.Time = "YxTq";
		subject.TransactionTypeCode = "lT";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		subject.TransactionSetPurposeCode = "2t";
		subject.Date = "81ZyTc8G";
		subject.Time = "YxTq";
		subject.TransactionTypeCode = "lT";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("81ZyTc8G", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		subject.TransactionSetPurposeCode = "2t";
		subject.ReferenceIdentification = "9";
		subject.Time = "YxTq";
		subject.TransactionTypeCode = "lT";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YxTq", true)]
	public void Validatation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		subject.TransactionSetPurposeCode = "2t";
		subject.ReferenceIdentification = "9";
		subject.Date = "81ZyTc8G";
		subject.TransactionTypeCode = "lT";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lT", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		subject.TransactionSetPurposeCode = "2t";
		subject.ReferenceIdentification = "9";
		subject.Date = "81ZyTc8G";
		subject.Time = "YxTq";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "w", true)]
	[InlineData("LEBIgOqq", "", false)]
	public void Validation_ARequiresBDate2(string date2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		subject.TransactionSetPurposeCode = "2t";
		subject.ReferenceIdentification = "9";
		subject.Date = "81ZyTc8G";
		subject.Time = "YxTq";
		subject.TransactionTypeCode = "lT";
		subject.Date2 = date2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "LEBIgOqq", true)]
	[InlineData("u2CZ", "", false)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		subject.TransactionSetPurposeCode = "2t";
		subject.ReferenceIdentification = "9";
		subject.Date = "81ZyTc8G";
		subject.Time = "YxTq";
		subject.TransactionTypeCode = "lT";
		subject.Time2 = time2;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
