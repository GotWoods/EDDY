using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SN1*v*6*Js*7*4*XQ*o*t3";

		var expected = new SN1_ItemDetailShipment()
		{
			AssignedIdentification = "v",
			NumberOfUnitsShipped = 6,
			UnitOrBasisForMeasurementCode = "Js",
			QuantityShippedToDate = 7,
			QuantityOrdered = 4,
			UnitOrBasisForMeasurementCode2 = "XQ",
			ReturnableContainerLoadMakeUpCode = "o",
			LineItemStatusCode = "t3",
		};

		var actual = Map.MapObject<SN1_ItemDetailShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.UnitOrBasisForMeasurementCode = "Js";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityOrdered = 4;
			subject.UnitOrBasisForMeasurementCode2 = "XQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Js", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityOrdered = 4;
			subject.UnitOrBasisForMeasurementCode2 = "XQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "XQ", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "XQ", false)]
	public void Validation_AllAreRequiredQuantityOrdered(decimal quantityOrdered, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 6;
		subject.UnitOrBasisForMeasurementCode = "Js";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
