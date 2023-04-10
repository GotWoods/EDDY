using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSI*A*f9Sk79vI*q*v*8*VL8p*Jt*Vd*7";

		var expected = new BSI_BeginningSegmentForOrderStatusInquiry()
		{
			ReferenceIdentification = "A",
			Date = "f9Sk79vI",
			OrderItemCode = "q",
			ProductDateCode = "v",
			LocationCode = "8",
			Time = "VL8p",
			TransactionSetPurposeCode = "Jt",
			TransactionTypeCode = "Vd",
			ActionCode = "7",
		};

		var actual = Map.MapObject<BSI_BeginningSegmentForOrderStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.Date = "f9Sk79vI";
		subject.OrderItemCode = "q";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f9Sk79vI", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceIdentification = "A";
		subject.OrderItemCode = "q";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validatation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceIdentification = "A";
		subject.Date = "f9Sk79vI";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
