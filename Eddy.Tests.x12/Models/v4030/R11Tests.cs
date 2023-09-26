using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class R11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R11*jj*BB*Ml*s*ob*7142*wj";

		var expected = new R11_BeginningSegmentForTrailerOrContainerRepairBilling()
		{
			TransactionTypeCode = "jj",
			StandardCarrierAlphaCode = "BB",
			StandardCarrierAlphaCode2 = "Ml",
			InvoiceNumber = "s",
			MonthOfTheYearCode = "ob",
			Year = 7142,
			TermsTypeCode = "wj",
		};

		var actual = Map.MapObject<R11_BeginningSegmentForTrailerOrContainerRepairBilling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jj", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.StandardCarrierAlphaCode = "BB";
		subject.StandardCarrierAlphaCode2 = "Ml";
		subject.InvoiceNumber = "s";
		subject.MonthOfTheYearCode = "ob";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BB", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "jj";
		subject.StandardCarrierAlphaCode2 = "Ml";
		subject.InvoiceNumber = "s";
		subject.MonthOfTheYearCode = "ob";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ml", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "jj";
		subject.StandardCarrierAlphaCode = "BB";
		subject.InvoiceNumber = "s";
		subject.MonthOfTheYearCode = "ob";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "jj";
		subject.StandardCarrierAlphaCode = "BB";
		subject.StandardCarrierAlphaCode2 = "Ml";
		subject.MonthOfTheYearCode = "ob";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ob", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new R11_BeginningSegmentForTrailerOrContainerRepairBilling();
		//Required fields
		subject.TransactionTypeCode = "jj";
		subject.StandardCarrierAlphaCode = "BB";
		subject.StandardCarrierAlphaCode2 = "Ml";
		subject.InvoiceNumber = "s";
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
