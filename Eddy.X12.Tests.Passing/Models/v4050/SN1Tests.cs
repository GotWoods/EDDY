using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SN1*g*8*ZO*2*5*pY*o*k7";

		var expected = new SN1_ItemDetailShipment()
		{
			AssignedIdentification = "g",
			NumberOfUnitsShipped = 8,
			UnitOrBasisForMeasurementCode = "ZO",
			QuantityShippedToDate = 2,
			Quantity = 5,
			UnitOrBasisForMeasurementCode2 = "pY",
			ReturnableContainerLoadMakeUpCode = "o",
			LineItemStatusCode = "k7",
		};

		var actual = Map.MapObject<SN1_ItemDetailShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.UnitOrBasisForMeasurementCode = "ZO";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Quantity = 5;
			subject.UnitOrBasisForMeasurementCode2 = "pY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZO", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Quantity = 5;
			subject.UnitOrBasisForMeasurementCode2 = "pY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "pY", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "pY", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "ZO";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
