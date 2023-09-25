using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W21*E*aw*V*fe*2*9*m*m*5*E*k*8*1*8*8*8*7*8";

		var expected = new W21_ItemDetailInventory()
		{
			WarehouseLotNumber = "E",
			ReferenceNumberQualifier = "aw",
			ReferenceNumber = "V",
			UnitOfMeasurementCode = "fe",
			QuantityOnHand = 2,
			Weight = 9,
			WeightQualifier = "m",
			WeightUnitQualifier = "m",
			Weight2 = 5,
			WeightQualifier2 = "E",
			WeightUnitQualifier2 = "k",
			QuantityDamaged = 8,
			QuantityOnHold = 1,
			QuantityCommitted = 8,
			QuantityAvailable = 8,
			QuantityInTransit = 8,
			QuantityBackordered = 7,
			QuantityDeferred = 8,
		};

		var actual = Map.MapObject<W21_ItemDetailInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredWarehouseLotNumber(string warehouseLotNumber, bool isValidExpected)
	{
		var subject = new W21_ItemDetailInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "fe";
		subject.QuantityOnHand = 2;
		//Test Parameters
		subject.WarehouseLotNumber = warehouseLotNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fe", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W21_ItemDetailInventory();
		//Required fields
		subject.WarehouseLotNumber = "E";
		subject.QuantityOnHand = 2;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityOnHand(decimal quantityOnHand, bool isValidExpected)
	{
		var subject = new W21_ItemDetailInventory();
		//Required fields
		subject.WarehouseLotNumber = "E";
		subject.UnitOfMeasurementCode = "fe";
		//Test Parameters
		if (quantityOnHand > 0) 
			subject.QuantityOnHand = quantityOnHand;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
