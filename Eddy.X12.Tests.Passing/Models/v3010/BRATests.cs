using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRA*c*52XrQH*Rs*u";

		var expected = new BRA_BeginningSegmentForReceivingAdvice()
		{
			ReferenceNumber = "c",
			Date = "52XrQH",
			TransactionSetPurposeCode = "Rs",
			ReceivingAdviceTypeCode = "u",
		};

		var actual = Map.MapObject<BRA_BeginningSegmentForReceivingAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.Date = "52XrQH";
		subject.TransactionSetPurposeCode = "Rs";
		subject.ReceivingAdviceTypeCode = "u";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("52XrQH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.ReferenceNumber = "c";
		subject.TransactionSetPurposeCode = "Rs";
		subject.ReceivingAdviceTypeCode = "u";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rs", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.ReferenceNumber = "c";
		subject.Date = "52XrQH";
		subject.ReceivingAdviceTypeCode = "u";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReceivingAdviceTypeCode(string receivingAdviceTypeCode, bool isValidExpected)
	{
		var subject = new BRA_BeginningSegmentForReceivingAdvice();
		subject.ReferenceNumber = "c";
		subject.Date = "52XrQH";
		subject.TransactionSetPurposeCode = "Rs";
		subject.ReceivingAdviceTypeCode = receivingAdviceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
