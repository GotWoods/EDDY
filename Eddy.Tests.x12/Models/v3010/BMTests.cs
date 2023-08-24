using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BM*G*sbGOGa*K*q3*yRuPrA*I*7*1";

		var expected = new BM_BeginningSegmentForMiscellaneousBilling()
		{
			InvoiceNumber = "G",
			BillingDate = "sbGOGa",
			NetAmountDue = "K",
			CorrectionIndicator = "q3",
			Date = "yRuPrA",
			BillingCode = "I",
			AssignedNumber = 7,
			SequenceNumberQualifier = 1,
		};

		var actual = Map.MapObject<BM_BeginningSegmentForMiscellaneousBilling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.BillingDate = "sbGOGa";
		subject.NetAmountDue = "K";
		subject.BillingCode = "I";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sbGOGa", true)]
	public void Validation_RequiredBillingDate(string billingDate, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "G";
		subject.NetAmountDue = "K";
		subject.BillingCode = "I";
		subject.BillingDate = billingDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "G";
		subject.BillingDate = "sbGOGa";
		subject.BillingCode = "I";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "G";
		subject.BillingDate = "sbGOGa";
		subject.NetAmountDue = "K";
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
