using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W19*Sk*9*8E*xZpPqIPGH7kR*Fm*f*4H*H*M*1*B*t*2*b*b";

		var expected = new W19_WarehouseAdjustmentItemDetail()
		{
			QuantityOrStatusAdjustmentReasonCode = "Sk",
			CreditDebitQuantity = 9,
			UnitOfMeasurementCode = "8E",
			UPCCaseCode = "xZpPqIPGH7kR",
			ProductServiceIDQualifier = "Fm",
			ProductServiceID = "f",
			ProductServiceIDQualifier2 = "4H",
			ProductServiceID2 = "H",
			WarehouseLotNumber = "M",
			Weight = 1,
			WeightQualifier = "B",
			WeightUnitQualifier = "t",
			Weight2 = 2,
			WeightQualifier2 = "b",
			WeightUnitQualifier2 = "b",
		};

		var actual = Map.MapObject<W19_WarehouseAdjustmentItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sk", true)]
	public void Validation_RequiredQuantityOrStatusAdjustmentReasonCode(string quantityOrStatusAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.CreditDebitQuantity = 9;
		subject.UnitOfMeasurementCode = "8E";
		//Test Parameters
		subject.QuantityOrStatusAdjustmentReasonCode = quantityOrStatusAdjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredCreditDebitQuantity(decimal creditDebitQuantity, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "Sk";
		subject.UnitOfMeasurementCode = "8E";
		//Test Parameters
		if (creditDebitQuantity > 0) 
			subject.CreditDebitQuantity = creditDebitQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8E", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W19_WarehouseAdjustmentItemDetail();
		//Required fields
		subject.QuantityOrStatusAdjustmentReasonCode = "Sk";
		subject.CreditDebitQuantity = 9;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
