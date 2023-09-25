using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTP*TY*T*jvecbPSa*A3LQ*eo*sk*D*jLliNIuv*d3kf*V7d";

		var expected = new BTP_BeginningSegmentForTradingPartnerProfile()
		{
			TransactionSetPurposeCode = "TY",
			ReferenceIdentification = "T",
			Date = "jvecbPSa",
			Time = "A3LQ",
			TransactionTypeCode = "eo",
			TransactionSetPurposeCode2 = "sk",
			ReferenceIdentification2 = "D",
			Date2 = "jLliNIuv",
			Time2 = "d3kf",
			PaymentMethodCode = "V7d",
		};

		var actual = Map.MapObject<BTP_BeginningSegmentForTradingPartnerProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TY", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.ReferenceIdentification = "T";
		subject.Date = "jvecbPSa";
		subject.Time = "A3LQ";
		subject.TransactionTypeCode = "eo";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "TY";
		subject.Date = "jvecbPSa";
		subject.Time = "A3LQ";
		subject.TransactionTypeCode = "eo";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jvecbPSa", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "TY";
		subject.ReferenceIdentification = "T";
		subject.Time = "A3LQ";
		subject.TransactionTypeCode = "eo";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A3LQ", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "TY";
		subject.ReferenceIdentification = "T";
		subject.Date = "jvecbPSa";
		subject.TransactionTypeCode = "eo";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eo", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "TY";
		subject.ReferenceIdentification = "T";
		subject.Date = "jvecbPSa";
		subject.Time = "A3LQ";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jLliNIuv", "D", true)]
	[InlineData("jLliNIuv", "", false)]
	[InlineData("", "D", true)]
	public void Validation_ARequiresBDate2(string date2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "TY";
		subject.ReferenceIdentification = "T";
		subject.Date = "jvecbPSa";
		subject.Time = "A3LQ";
		subject.TransactionTypeCode = "eo";
		//Test Parameters
		subject.Date2 = date2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d3kf", "jLliNIuv", true)]
	[InlineData("d3kf", "", false)]
	[InlineData("", "jLliNIuv", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "TY";
		subject.ReferenceIdentification = "T";
		subject.Date = "jvecbPSa";
		subject.Time = "A3LQ";
		subject.TransactionTypeCode = "eo";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;
		//A Requires B
		if (date2 != "")
			subject.ReferenceIdentification2 = "D";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
