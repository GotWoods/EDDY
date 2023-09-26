using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCQ*HF*RFGb5CGH*0twZ*L*8j*hx*g";

		var expected = new BCQ_BeginningSegmentForShippersCarOrder()
		{
			TransactionSetPurposeCode = "HF",
			Date = "RFGb5CGH",
			Time = "0twZ",
			ReferenceIdentification = "L",
			StandardCarrierAlphaCode = "8j",
			TransactionTypeCode = "hx",
			IndustryCode = "g",
		};

		var actual = Map.MapObject<BCQ_BeginningSegmentForShippersCarOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HF", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.Date = "RFGb5CGH";
		subject.Time = "0twZ";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RFGb5CGH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "HF";
		subject.Time = "0twZ";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0twZ", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "HF";
		subject.Date = "RFGb5CGH";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
