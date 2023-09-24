using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSR*t*r*l*VvOvNt*b*N*4O9B*c*SFe6jl*O3F2*pX*W";

		var expected = new BSR_BeginningSegmentForOrderStatusReport()
		{
			StatusReportCode = "t",
			OrderItemCode = "r",
			ReferenceNumber = "l",
			Date = "VvOvNt",
			ProductDateCode = "b",
			LocationCode = "N",
			Time = "4O9B",
			ReferenceNumber2 = "c",
			Date2 = "SFe6jl",
			Time2 = "O3F2",
			TransactionSetPurposeCode = "pX",
			ActionCode = "W",
		};

		var actual = Map.MapObject<BSR_BeginningSegmentForOrderStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredStatusReportCode(string statusReportCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.OrderItemCode = "r";
		subject.ReferenceNumber = "l";
		subject.Date = "VvOvNt";
		subject.StatusReportCode = statusReportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "t";
		subject.ReferenceNumber = "l";
		subject.Date = "VvOvNt";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "t";
		subject.OrderItemCode = "r";
		subject.Date = "VvOvNt";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VvOvNt", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "t";
		subject.OrderItemCode = "r";
		subject.ReferenceNumber = "l";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
