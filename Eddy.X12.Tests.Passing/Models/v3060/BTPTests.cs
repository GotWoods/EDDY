using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTP*0B*G*GEBhjf*y07d*9C*Lw*F*fXi2gU*RII5*taZ";

		var expected = new BTP_BeginningSegmentForTradingPartnerProfile()
		{
			TransactionSetPurposeCode = "0B",
			ReferenceIdentification = "G",
			Date = "GEBhjf",
			Time = "y07d",
			TransactionTypeCode = "9C",
			TransactionSetPurposeCode2 = "Lw",
			ReferenceIdentification2 = "F",
			Date2 = "fXi2gU",
			Time2 = "RII5",
			PaymentMethodCode = "taZ",
		};

		var actual = Map.MapObject<BTP_BeginningSegmentForTradingPartnerProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0B", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.ReferenceIdentification = "G";
		subject.Date = "GEBhjf";
		subject.Time = "y07d";
		subject.TransactionTypeCode = "9C";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "0B";
		subject.Date = "GEBhjf";
		subject.Time = "y07d";
		subject.TransactionTypeCode = "9C";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GEBhjf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "0B";
		subject.ReferenceIdentification = "G";
		subject.Time = "y07d";
		subject.TransactionTypeCode = "9C";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y07d", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "0B";
		subject.ReferenceIdentification = "G";
		subject.Date = "GEBhjf";
		subject.TransactionTypeCode = "9C";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9C", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "0B";
		subject.ReferenceIdentification = "G";
		subject.Date = "GEBhjf";
		subject.Time = "y07d";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fXi2gU", "F", true)]
	[InlineData("fXi2gU", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBDate2(string date2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "0B";
		subject.ReferenceIdentification = "G";
		subject.Date = "GEBhjf";
		subject.Time = "y07d";
		subject.TransactionTypeCode = "9C";
		//Test Parameters
		subject.Date2 = date2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RII5", "fXi2gU", true)]
	[InlineData("RII5", "", false)]
	[InlineData("", "fXi2gU", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "0B";
		subject.ReferenceIdentification = "G";
		subject.Date = "GEBhjf";
		subject.Time = "y07d";
		subject.TransactionTypeCode = "9C";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;
		//A Requires B
		if (date2 != "")
			subject.ReferenceIdentification2 = "F";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
