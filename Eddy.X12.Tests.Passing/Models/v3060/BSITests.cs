using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSI*g*tsJnch*4*T*8*qT45*YR*zT*U";

		var expected = new BSI_BeginningSegmentForOrderStatusInquiry()
		{
			ReferenceIdentification = "g",
			Date = "tsJnch",
			OrderItemCode = "4",
			ProductDateCode = "T",
			LocationCode = "8",
			Time = "qT45",
			TransactionSetPurposeCode = "YR",
			TransactionTypeCode = "zT",
			ActionCode = "U",
		};

		var actual = Map.MapObject<BSI_BeginningSegmentForOrderStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.Date = "tsJnch";
		subject.OrderItemCode = "4";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tsJnch", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceIdentification = "g";
		subject.OrderItemCode = "4";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceIdentification = "g";
		subject.Date = "tsJnch";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
