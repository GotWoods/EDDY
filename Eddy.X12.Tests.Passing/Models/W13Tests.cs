using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W13*5*I6*Cv*0*kF";

		var expected = new W13_ItemDetailException()
		{
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "I6",
			ReceivingConditionCode = "Cv",
			WarehouseLotNumber = "0",
			DamageReasonCode = "kF",
		};

		var actual = Map.MapObject<W13_ItemDetailException>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		subject.UnitOrBasisForMeasurementCode = "I6";
		subject.ReceivingConditionCode = "Cv";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I6", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		subject.Quantity = 5;
		subject.ReceivingConditionCode = "Cv";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cv", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "I6";
		subject.ReceivingConditionCode = receivingConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
