using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSR*0*F*Q*zWsmkwk9*1*B*yRwM*N*zuqsxLn1*6RQm*k4*E";

		var expected = new BSR_BeginningSegmentForOrderStatusReport()
		{
			StatusReportCode = "0",
			OrderItemCode = "F",
			ReferenceIdentification = "Q",
			Date = "zWsmkwk9",
			ProductDateCode = "1",
			LocationCode = "B",
			Time = "yRwM",
			ReferenceIdentification2 = "N",
			Date2 = "zuqsxLn1",
			Time2 = "6RQm",
			TransactionSetPurposeCode = "k4",
			ActionCode = "E",
		};

		var actual = Map.MapObject<BSR_BeginningSegmentForOrderStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredStatusReportCode(string statusReportCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.OrderItemCode = "F";
		subject.ReferenceIdentification = "Q";
		subject.Date = "zWsmkwk9";
		subject.StatusReportCode = statusReportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "0";
		subject.ReferenceIdentification = "Q";
		subject.Date = "zWsmkwk9";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "0";
		subject.OrderItemCode = "F";
		subject.Date = "zWsmkwk9";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zWsmkwk9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "0";
		subject.OrderItemCode = "F";
		subject.ReferenceIdentification = "Q";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
