using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSR*2*P*T*fXTNANtc*X*v*VLlL*P*L9e8ydpt*sQNU*N4*v";

		var expected = new BSR_BeginningSegmentForOrderStatusReport()
		{
			StatusReportCode = "2",
			OrderItemCode = "P",
			ReferenceIdentification = "T",
			Date = "fXTNANtc",
			ProductDateCode = "X",
			LocationCode = "v",
			Time = "VLlL",
			ReferenceIdentification2 = "P",
			Date2 = "L9e8ydpt",
			Time2 = "sQNU",
			TransactionSetPurposeCode = "N4",
			ActionCode = "v",
		};

		var actual = Map.MapObject<BSR_BeginningSegmentForOrderStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredStatusReportCode(string statusReportCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.OrderItemCode = "P";
		subject.ReferenceIdentification = "T";
		subject.Date = "fXTNANtc";
		subject.StatusReportCode = statusReportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredOrderItemCode(string orderItemCode, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "2";
		subject.ReferenceIdentification = "T";
		subject.Date = "fXTNANtc";
		subject.OrderItemCode = orderItemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "2";
		subject.OrderItemCode = "P";
		subject.Date = "fXTNANtc";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fXTNANtc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSR_BeginningSegmentForOrderStatusReport();
		subject.StatusReportCode = "2";
		subject.OrderItemCode = "P";
		subject.ReferenceIdentification = "T";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
