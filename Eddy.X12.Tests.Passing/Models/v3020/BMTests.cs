using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BM*X*jko0fI*J*yi*ug0JZH*n*3*3";

		var expected = new BM_BeginningSegmentForMiscellaneousBilling()
		{
			InvoiceNumber = "X",
			Date = "jko0fI",
			NetAmountDue = "J",
			CorrectionIndicator = "yi",
			Date2 = "ug0JZH",
			BillingCode = "n",
			AssignedNumber = 3,
			SequenceNumberQualifier = 3,
		};

		var actual = Map.MapObject<BM_BeginningSegmentForMiscellaneousBilling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.Date = "jko0fI";
		subject.NetAmountDue = "J";
		subject.BillingCode = "n";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jko0fI", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "X";
		subject.NetAmountDue = "J";
		subject.BillingCode = "n";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "X";
		subject.Date = "jko0fI";
		subject.BillingCode = "n";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "X";
		subject.Date = "jko0fI";
		subject.NetAmountDue = "J";
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
