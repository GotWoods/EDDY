using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BM*V*FRqE5h*7*WL*KGiQLi*3*4*6";

		var expected = new BM_BeginningSegmentForMiscellaneousBilling()
		{
			InvoiceNumber = "V",
			BillingDate = "FRqE5h",
			NetAmountDue = "7",
			CorrectionIndicator = "WL",
			Date = "KGiQLi",
			BillingCode = "3",
			AssignedNumber = 4,
			SequenceNumberQualifier = 6,
		};

		var actual = Map.MapObject<BM_BeginningSegmentForMiscellaneousBilling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.BillingDate = "FRqE5h";
		subject.NetAmountDue = "7";
		subject.BillingCode = "3";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FRqE5h", true)]
	public void Validation_RequiredBillingDate(string billingDate, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "V";
		subject.NetAmountDue = "7";
		subject.BillingCode = "3";
		subject.BillingDate = billingDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "V";
		subject.BillingDate = "FRqE5h";
		subject.BillingCode = "3";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "V";
		subject.BillingDate = "FRqE5h";
		subject.NetAmountDue = "7";
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
