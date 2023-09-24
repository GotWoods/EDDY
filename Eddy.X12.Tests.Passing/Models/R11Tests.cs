using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R11*M4*SV*mr*M*bL*3629*FH*y";

		var expected = new R11_BeginningSegmentForTrailerOrContainerRepairBilling()
		{
			TransactionTypeCode = "M4",
			StandardCarrierAlphaCode = "SV",
			StandardCarrierAlphaCode2 = "mr",
			InvoiceNumber = "M",
			MonthOfTheYearCode = "bL",
			Year = 3629,
			TermsTypeCode = "FH",
			NetAmountDue = "y",
		};

		var actual = Map.MapObject<R11_BeginningSegmentForTrailerOrContainerRepairBilling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M4", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		subject.StandardCarrierAlphaCode = "SV";
		subject.StandardCarrierAlphaCode2 = "mr";
		subject.InvoiceNumber = "M";
		subject.MonthOfTheYearCode = "bL";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		subject.TransactionTypeCode = "M4";
		subject.StandardCarrierAlphaCode2 = "mr";
		subject.InvoiceNumber = "M";
		subject.MonthOfTheYearCode = "bL";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mr", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		subject.TransactionTypeCode = "M4";
		subject.StandardCarrierAlphaCode = "SV";
		subject.InvoiceNumber = "M";
		subject.MonthOfTheYearCode = "bL";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		subject.TransactionTypeCode = "M4";
		subject.StandardCarrierAlphaCode = "SV";
		subject.StandardCarrierAlphaCode2 = "mr";
		subject.MonthOfTheYearCode = "bL";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bL", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		subject.TransactionTypeCode = "M4";
		subject.StandardCarrierAlphaCode = "SV";
		subject.StandardCarrierAlphaCode2 = "mr";
		subject.InvoiceNumber = "M";
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
