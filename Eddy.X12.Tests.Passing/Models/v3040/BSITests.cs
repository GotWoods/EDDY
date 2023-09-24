using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSI*o*wNRJGz*3*N*d*GhY1";

		var expected = new BSI_BeginningSegmentForOrderStatusInquiry()
		{
			ReferenceNumber = "o",
			Date = "wNRJGz",
			OrderItemCode = "3",
			ProductDateCode = "N",
			LocationCode = "d",
			Time = "GhY1",
		};

		var actual = Map.MapObject<BSI_BeginningSegmentForOrderStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.Date = "wNRJGz";
		subject.OrderItemCode = "3";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wNRJGz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceNumber = "o";
		subject.OrderItemCode = "3";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSI_BeginningSegmentForOrderStatusInquiry();
		subject.ReferenceNumber = "o";
		subject.Date = "wNRJGz";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
