using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CF2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CF2*O*Y*u*7a*T0CUq0j1*pKlop7mZ*2*D*9*S1";

		var expected = new CF2_SummaryFreightBillDetail()
		{
			InvoiceNumber = "O",
			NetAmountDue = "Y",
			ShipmentIdentificationNumber = "u",
			ShipmentMethodOfPaymentCode = "7a",
			Date = "T0CUq0j1",
			Date2 = "pKlop7mZ",
			WeightQualifier = "2",
			WeightUnitCode = "D",
			Weight = 9,
			TransactionTypeCode = "S1",
		};

		var actual = Map.MapObject<CF2_SummaryFreightBillDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.NetAmountDue = "Y";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		//If one, at least one
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "2";
			subject.WeightUnitCode = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "O";
		//Test Parameters
		subject.NetAmountDue = netAmountDue;
		//If one, at least one
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "2";
			subject.WeightUnitCode = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 9, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "O";
		subject.NetAmountDue = "Y";
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		//If one, at least one
		if(subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightUnitCode = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 9, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "O";
		subject.NetAmountDue = "Y";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one, at least one
		if(subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.WeightQualifier = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(9, "2", "D", true)]
	[InlineData(9, "", "", false)]
	[InlineData(0, "2", "D", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Weight(decimal weight, string weightQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "O";
		subject.NetAmountDue = "Y";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		subject.WeightUnitCode = weightUnitCode;
		//A Requires B
		if (weightQualifier != "")
			subject.Weight = 9;
		if (weightUnitCode != "")
			subject.Weight = 9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
