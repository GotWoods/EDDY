using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSR*F*S*Q*3ba2Ui*0*C*vvm0*o*tePcdr*2R5W";

		var expected = new BSR_BeginningSegmentForOrderStatusReport()
		{
			StatusReportCode = "F",
			OrderItemCode = "S",
			ReferenceNumber = "Q",
			Date = "3ba2Ui",
			ProductDateCode = "0",
			LocationCode = "C",
			Time = "vvm0",
			ReferenceNumber2 = "o",
			Date2 = "tePcdr",
			Time2 = "2R5W",
		};

		var actual = Map.MapObject<BSR_BeginningSegmentForOrderStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredStatusReportCode(string statusReportCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.OrderItemCode = "S";
		subject.ReferenceNumber = "Q";
		subject.Date = "3ba2Ui";
		subject.StatusReportCode = statusReportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "F";
		subject.ReferenceNumber = "Q";
		subject.Date = "3ba2Ui";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "F";
		subject.OrderItemCode = "S";
		subject.Date = "3ba2Ui";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3ba2Ui", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "F";
		subject.OrderItemCode = "S";
		subject.ReferenceNumber = "Q";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
