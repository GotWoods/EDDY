using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CF2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CF2*S*T*T*ks*fTigx9o1*gMfY080I*p*q*3*cR";

		var expected = new CF2_SummaryFreightBillDetail()
		{
			InvoiceNumber = "S",
			NetAmountDue = "T",
			ShipmentIdentificationNumber = "T",
			ShipmentMethodOfPaymentCode = "ks",
			Date = "fTigx9o1",
			Date2 = "gMfY080I",
			WeightQualifier = "p",
			WeightUnitCode = "q",
			Weight = 3,
			TransactionTypeCode = "cR",
		};

		var actual = Map.MapObject<CF2_SummaryFreightBillDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validatation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		subject.NetAmountDue = "T";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validatation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		subject.InvoiceNumber = "S";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 3, true)]
	[InlineData("p", 0, false)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		subject.InvoiceNumber = "S";
		subject.NetAmountDue = "T";
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
		{
			subject.Weight = weight;
			subject.WeightUnitCode = "A";
		}

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 3, true)]
	[InlineData("q", 0, false)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		subject.InvoiceNumber = "S";
		subject.NetAmountDue = "T";
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	//TODO: enable this
	// [Theory]
	// [InlineData(0,"", true)]
	// [InlineData(3, "p", false)]
	// [InlineData(0,"p", true)]
	// [InlineData(3, "", true)]
	// public void Validation_NEWWeight(decimal weight, string weightQualifier, string weightUnitCode, bool isValidExpected)
	// {
	// 	var subject = new CF2_SummaryFreightBillDetail();
	// 	subject.InvoiceNumber = "S";
	// 	subject.NetAmountDue = "T";
	// 	if (weight > 0)
	// 	subject.Weight = weight;
	// 	subject.WeightQualifier = weightQualifier;
	// 	subject.WeightUnitCode = weightUnitCode;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	// }

}
