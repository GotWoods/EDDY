using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BM*a*mEpZgG*B*KW*4QacEj*X*6*8";

		var expected = new BM_BeginningSegmentForMiscellaneousBilling()
		{
			InvoiceNumber = "a",
			Date = "mEpZgG",
			Amount = "B",
			CorrectionIndicator = "KW",
			Date2 = "4QacEj",
			BillingCode = "X",
			AssignedNumber = 6,
			SequenceNumberQualifier = 8,
		};

		var actual = Map.MapObject<BM_BeginningSegmentForMiscellaneousBilling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.Date = "mEpZgG";
		subject.Amount = "B";
		subject.BillingCode = "X";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mEpZgG", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "a";
		subject.Amount = "B";
		subject.BillingCode = "X";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "a";
		subject.Date = "mEpZgG";
		subject.BillingCode = "X";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BM_BeginningSegmentForMiscellaneousBilling();
		subject.InvoiceNumber = "a";
		subject.Date = "mEpZgG";
		subject.Amount = "B";
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
