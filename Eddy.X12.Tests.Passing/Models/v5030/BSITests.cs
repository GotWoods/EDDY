using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSI*T*v7usc6eg*f*z*a*9Z8q*wS*X9*v";

		var expected = new BSI_BeginningSegmentForOrderStatusInquiry()
		{
			ReferenceIdentification = "T",
			Date = "v7usc6eg",
			OrderItemCode = "f",
			ProductDateCode = "z",
			LocationCode = "a",
			Time = "9Z8q",
			TransactionSetPurposeCode = "wS",
			TransactionTypeCode = "X9",
			ActionCode = "v",
		};

		var actual = Map.MapObject<BSI_BeginningSegmentForOrderStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.Date = "v7usc6eg";
		subject.OrderItemCode = "f";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v7usc6eg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceIdentification = "T";
		subject.OrderItemCode = "f";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceIdentification = "T";
		subject.Date = "v7usc6eg";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
