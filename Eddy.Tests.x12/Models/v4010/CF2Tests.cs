using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CF2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CF2*P*z*D*fI*Jy6zMQjs*lUwiuqns*T*k*9*k9";

		var expected = new CF2_SummaryFreightBillDetail()
		{
			InvoiceNumber = "P",
			NetAmountDue = "z",
			ShipmentIdentificationNumber = "D",
			ShipmentMethodOfPayment = "fI",
			Date = "Jy6zMQjs",
			Date2 = "lUwiuqns",
			WeightQualifier = "T",
			WeightUnitCode = "k",
			Weight = 9,
			TransactionTypeCode = "k9",
		};

		var actual = Map.MapObject<CF2_SummaryFreightBillDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.NetAmountDue = "z";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		//If one, at least one
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "T";
			subject.WeightUnitCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "P";
		//Test Parameters
		subject.NetAmountDue = netAmountDue;
		//If one, at least one
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 9;
			subject.WeightQualifier = "T";
			subject.WeightUnitCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("T", 9, true)]
	[InlineData("T", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "P";
		subject.NetAmountDue = "z";
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		//If one, at least one
		if(subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.WeightUnitCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("k", 9, true)]
	[InlineData("k", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "P";
		subject.NetAmountDue = "z";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one, at least one
		if(subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.WeightQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(9, "T", "k", true)]
	[InlineData(9, "", "", false)]
	[InlineData(0, "T", "k", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Weight(decimal weight, string weightQualifier, string weightUnitCode, bool isValidExpected)
	{
		var subject = new CF2_SummaryFreightBillDetail();
		//Required fields
		subject.InvoiceNumber = "P";
		subject.NetAmountDue = "z";
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
