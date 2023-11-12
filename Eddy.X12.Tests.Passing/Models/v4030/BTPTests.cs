using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTP*Mr*7*vg5nCkQ3*wF93*05*UN*z*yw1zIRVt*hEcp*wQ0";

		var expected = new BTP_BeginningSegmentForTradingPartnerProfile()
		{
			TransactionSetPurposeCode = "Mr",
			ReferenceIdentification = "7",
			Date = "vg5nCkQ3",
			Time = "wF93",
			TransactionTypeCode = "05",
			TransactionSetPurposeCode2 = "UN",
			ReferenceIdentification2 = "z",
			Date2 = "yw1zIRVt",
			Time2 = "hEcp",
			PaymentMethodCode = "wQ0",
		};

		var actual = Map.MapObject<BTP_BeginningSegmentForTradingPartnerProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mr", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.ReferenceIdentification = "7";
		subject.Date = "vg5nCkQ3";
		subject.Time = "wF93";
		subject.TransactionTypeCode = "05";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Mr";
		subject.Date = "vg5nCkQ3";
		subject.Time = "wF93";
		subject.TransactionTypeCode = "05";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vg5nCkQ3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Mr";
		subject.ReferenceIdentification = "7";
		subject.Time = "wF93";
		subject.TransactionTypeCode = "05";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wF93", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Mr";
		subject.ReferenceIdentification = "7";
		subject.Date = "vg5nCkQ3";
		subject.TransactionTypeCode = "05";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("05", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Mr";
		subject.ReferenceIdentification = "7";
		subject.Date = "vg5nCkQ3";
		subject.Time = "wF93";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yw1zIRVt", "z", true)]
	[InlineData("yw1zIRVt", "", false)]
	[InlineData("", "z", true)]
	public void Validation_ARequiresBDate2(string date2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Mr";
		subject.ReferenceIdentification = "7";
		subject.Date = "vg5nCkQ3";
		subject.Time = "wF93";
		subject.TransactionTypeCode = "05";
		//Test Parameters
		subject.Date2 = date2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hEcp", "yw1zIRVt", true)]
	[InlineData("hEcp", "", false)]
	[InlineData("", "yw1zIRVt", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Mr";
		subject.ReferenceIdentification = "7";
		subject.Date = "vg5nCkQ3";
		subject.Time = "wF93";
		subject.TransactionTypeCode = "05";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;
		//A Requires B
		if (date2 != "")
			subject.ReferenceIdentification2 = "z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
