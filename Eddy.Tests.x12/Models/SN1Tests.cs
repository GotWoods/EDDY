using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SN1*S*4*Db*6*7*dP*w*7W";

		var expected = new SN1_ItemDetailShipment()
		{
			AssignedIdentification = "S",
			NumberOfUnitsShipped = 4,
			UnitOrBasisForMeasurementCode = "Db",
			QuantityShippedToDate = 6,
			Quantity = 7,
			UnitOrBasisForMeasurementCode2 = "dP",
			ReturnableContainerLoadMakeUpCode = "w",
			LineItemStatusCode = "7W",
		};

		var actual = Map.MapObject<SN1_ItemDetailShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.UnitOrBasisForMeasurementCode = "Db";
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Db", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "dP", true)]
	[InlineData(0, "dP", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 4;
		subject.UnitOrBasisForMeasurementCode = "Db";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
