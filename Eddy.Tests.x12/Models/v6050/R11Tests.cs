using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class R11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R11*5z*PB*rd*j*ra*2587*ay*m";

		var expected = new R11_BeginningSegmentForTrailerOrContainerRepairBilling()
		{
			TransactionTypeCode = "5z",
			StandardCarrierAlphaCode = "PB",
			StandardCarrierAlphaCode2 = "rd",
			InvoiceNumber = "j",
			MonthOfTheYearCode = "ra",
			Year = 2587,
			TermsTypeCode = "ay",
			NetAmountDue = "m",
		};

		var actual = Map.MapObject<R11_BeginningSegmentForTrailerOrContainerRepairBilling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5z", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.StandardCarrierAlphaCode = "PB";
		subject.StandardCarrierAlphaCode2 = "rd";
		subject.InvoiceNumber = "j";
		subject.MonthOfTheYearCode = "ra";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PB", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "5z";
		subject.StandardCarrierAlphaCode2 = "rd";
		subject.InvoiceNumber = "j";
		subject.MonthOfTheYearCode = "ra";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rd", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "5z";
		subject.StandardCarrierAlphaCode = "PB";
		subject.InvoiceNumber = "j";
		subject.MonthOfTheYearCode = "ra";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "5z";
		subject.StandardCarrierAlphaCode = "PB";
		subject.StandardCarrierAlphaCode2 = "rd";
		subject.MonthOfTheYearCode = "ra";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ra", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "5z";
		subject.StandardCarrierAlphaCode = "PB";
		subject.StandardCarrierAlphaCode2 = "rd";
		subject.InvoiceNumber = "j";
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
