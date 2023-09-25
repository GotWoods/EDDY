using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTP*Jb*T*rb7vsA*NE6H*ql*6g*3*aE736N*85sr";

		var expected = new BTP_BeginningSegmentForTradingPartnerProfile()
		{
			TransactionSetPurposeCode = "Jb",
			ReferenceNumber = "T",
			Date = "rb7vsA",
			Time = "NE6H",
			TransactionTypeCode = "ql",
			TransactionSetPurposeCode2 = "6g",
			ReferenceNumber2 = "3",
			Date2 = "aE736N",
			Time2 = "85sr",
		};

		var actual = Map.MapObject<BTP_BeginningSegmentForTradingPartnerProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jb", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.ReferenceNumber = "T";
		subject.Date = "rb7vsA";
		subject.Time = "NE6H";
		subject.TransactionTypeCode = "ql";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Jb";
		subject.Date = "rb7vsA";
		subject.Time = "NE6H";
		subject.TransactionTypeCode = "ql";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rb7vsA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Jb";
		subject.ReferenceNumber = "T";
		subject.Time = "NE6H";
		subject.TransactionTypeCode = "ql";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NE6H", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Jb";
		subject.ReferenceNumber = "T";
		subject.Date = "rb7vsA";
		subject.TransactionTypeCode = "ql";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ql", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Jb";
		subject.ReferenceNumber = "T";
		subject.Date = "rb7vsA";
		subject.Time = "NE6H";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aE736N", "3", true)]
	[InlineData("aE736N", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBDate2(string date2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Jb";
		subject.ReferenceNumber = "T";
		subject.Date = "rb7vsA";
		subject.Time = "NE6H";
		subject.TransactionTypeCode = "ql";
		//Test Parameters
		subject.Date2 = date2;
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("85sr", "aE736N", true)]
	[InlineData("85sr", "", false)]
	[InlineData("", "aE736N", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BTP_BeginningSegmentForTradingPartnerProfile();
		//Required fields
		subject.TransactionSetPurposeCode = "Jb";
		subject.ReferenceNumber = "T";
		subject.Date = "rb7vsA";
		subject.Time = "NE6H";
		subject.TransactionTypeCode = "ql";
		//Test Parameters
		subject.Time2 = time2;
		subject.Date2 = date2;
		//A Requires B
		if (date2 != "")
			subject.ReferenceNumber2 = "3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
