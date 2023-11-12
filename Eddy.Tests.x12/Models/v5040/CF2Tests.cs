using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class CF2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CF2*J*V*u*p7*Qgga6Lbm*Zsx41Rf3*n*4*3*uD";

		var expected = new CF2_SummaryFreightBillDetail()
		{
			InvoiceNumber = "J",
			NetAmountDue = "V",
			ShipmentIdentificationNumber = "u",
			ShipmentMethodOfPayment = "p7",
			Date = "Qgga6Lbm",
			Date2 = "Zsx41Rf3",
			WeightQualifier = "n",
			WeightUnitCode = "4",
			Weight = 3,
			TransactionTypeCode = "uD",
		};

		var actual = Map.MapObject<CF2_SummaryFreightBillDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.NetAmountDue = "V";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		//If one, at least one
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "n";
			subject.WeightUnitCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "J";
		//Test Parameters
		subject.NetAmountDue = netAmountDue;
		//If one, at least one
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "n";
			subject.WeightUnitCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 3, true)]
	[InlineData("n", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "J";
		subject.NetAmountDue = "V";
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		//If one, at least one
		if(subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightUnitCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4", 3, true)]
	[InlineData("4", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "J";
		subject.NetAmountDue = "V";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one, at least one
		if(subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.WeightQualifier = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(3, "n", "4", true)]
	[InlineData(3, "", "", false)]
	[InlineData(0, "n", "4", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Weight(decimal weight, string weightQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "J";
		subject.NetAmountDue = "V";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		subject.WeightUnitCode = weightUnitCode;
		//A Requires B
		if (weightQualifier != "")
			subject.Weight = 3;
		if (weightUnitCode != "")
			subject.Weight = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
