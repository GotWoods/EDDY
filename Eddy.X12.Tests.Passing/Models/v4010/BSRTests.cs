using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSR*x*U*C*wFgp9jCR*R*C*BK9s*x*QwfJp8wm*sEgH*fn*4";

		var expected = new BSR_BeginningSegmentForOrderStatusReport()
		{
			StatusReportCode = "x",
			OrderItemCode = "U",
			ReferenceIdentification = "C",
			Date = "wFgp9jCR",
			ProductDateCode = "R",
			LocationCode = "C",
			Time = "BK9s",
			ReferenceIdentification2 = "x",
			Date2 = "QwfJp8wm",
			Time2 = "sEgH",
			TransactionSetPurposeCode = "fn",
			ActionCode = "4",
		};

		var actual = Map.MapObject<BSR_BeginningSegmentForOrderStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredStatusReportCode(string statusReportCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.OrderItemCode = "U";
		subject.ReferenceIdentification = "C";
		subject.Date = "wFgp9jCR";
		subject.StatusReportCode = statusReportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "x";
		subject.ReferenceIdentification = "C";
		subject.Date = "wFgp9jCR";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "x";
		subject.OrderItemCode = "U";
		subject.Date = "wFgp9jCR";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wFgp9jCR", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "x";
		subject.OrderItemCode = "U";
		subject.ReferenceIdentification = "C";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
