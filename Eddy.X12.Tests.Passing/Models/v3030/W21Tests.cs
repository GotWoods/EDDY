using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W21*w*BV*C*bz*2*8*g*9*1*i*b*2*3*2*5*8*6*4";

		var expected = new W21_ItemDetailInventory()
		{
			WarehouseLotNumber = "w",
			ReferenceNumberQualifier = "BV",
			ReferenceNumber = "C",
			UnitOrBasisForMeasurementCode = "bz",
			QuantityOnHand = 2,
			Weight = 8,
			WeightQualifier = "g",
			WeightUnitCode = "9",
			Weight2 = 1,
			WeightQualifier2 = "i",
			WeightUnitCode2 = "b",
			QuantityDamaged = 2,
			QuantityOnHold = 3,
			QuantityCommitted = 2,
			QuantityAvailable = 5,
			QuantityInTransit = 8,
			QuantityBackordered = 6,
			QuantityDeferred = 4,
		};

		var actual = Map.MapObject<W21_ItemDetailInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredWarehouseLotNumber(string warehouseLotNumber, bool isValidExpected)
	{
		var subject = new W21_ItemDetailInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "bz";
		subject.QuantityOnHand = 2;
		//Test Parameters
		subject.WarehouseLotNumber = warehouseLotNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bz", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W21_ItemDetailInventory();
		//Required fields
		subject.WarehouseLotNumber = "w";
		subject.QuantityOnHand = 2;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityOnHand(decimal quantityOnHand, bool isValidExpected)
	{
		var subject = new W21_ItemDetailInventory();
		//Required fields
		subject.WarehouseLotNumber = "w";
		subject.UnitOrBasisForMeasurementCode = "bz";
		//Test Parameters
		if (quantityOnHand > 0) 
			subject.QuantityOnHand = quantityOnHand;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
