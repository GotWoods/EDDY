using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BCQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCQ*lo*KafjARHj*0b0B*t*qR*UY*1";

		var expected = new BCQ_BeginningSegmentForShippersCarOrder()
		{
			TransactionSetPurposeCode = "lo",
			Date = "KafjARHj",
			Time = "0b0B",
			ReferenceIdentification = "t",
			StandardCarrierAlphaCode = "qR",
			TransactionTypeCode = "UY",
			IndustryCode = "1",
		};

		var actual = Map.MapObject<BCQ_BeginningSegmentForShippersCarOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lo", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		subject.Date = "KafjARHj";
		subject.Time = "0b0B";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KafjARHj", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		subject.TransactionSetPurposeCode = "lo";
		subject.Time = "0b0B";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0b0B", true)]
	public void Validatation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		subject.TransactionSetPurposeCode = "lo";
		subject.Date = "KafjARHj";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
