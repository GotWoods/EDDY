using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSR*g*a*i*bq6TSk9X*t*T*1DJC*g*A72Ji4fR*VLhA*cW*1";

		var expected = new BSR_BeginningSegmentForOrderStatusReport()
		{
			StatusReportCode = "g",
			OrderItemCode = "a",
			ReferenceIdentification = "i",
			Date = "bq6TSk9X",
			ProductDateCode = "t",
			LocationCode = "T",
			Time = "1DJC",
			ReferenceIdentification2 = "g",
			Date2 = "A72Ji4fR",
			Time2 = "VLhA",
			TransactionSetPurposeCode = "cW",
			ActionCode = "1",
		};

		var actual = Map.MapObject<BSR_BeginningSegmentForOrderStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredStatusReportCode(string statusReportCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.OrderItemCode = "a";
		subject.ReferenceIdentification = "i";
		subject.Date = "bq6TSk9X";
		subject.StatusReportCode = statusReportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "g";
		subject.ReferenceIdentification = "i";
		subject.Date = "bq6TSk9X";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "g";
		subject.OrderItemCode = "a";
		subject.Date = "bq6TSk9X";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bq6TSk9X", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "g";
		subject.OrderItemCode = "a";
		subject.ReferenceIdentification = "i";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
