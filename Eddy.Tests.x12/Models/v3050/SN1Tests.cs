using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SN1*i*7*vV*2*2*HW*c*yz";

		var expected = new SN1_ItemDetailShipment()
		{
			AssignedIdentification = "i",
			NumberOfUnitsShipped = 7,
			UnitOrBasisForMeasurementCode = "vV",
			QuantityShippedToDate = 2,
			QuantityOrdered = 2,
			UnitOrBasisForMeasurementCode2 = "HW",
			ReturnableContainerLoadMakeUpCode = "c",
			LineItemStatusCode = "yz",
		};

		var actual = Map.MapObject<SN1_ItemDetailShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.UnitOrBasisForMeasurementCode = "vV";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityOrdered = 2;
			subject.UnitOrBasisForMeasurementCode2 = "HW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vV", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 7;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityOrdered = 2;
			subject.UnitOrBasisForMeasurementCode2 = "HW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "HW", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "HW", false)]
	public void Validation_AllAreRequiredQuantityOrdered(decimal quantityOrdered, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 7;
		subject.UnitOrBasisForMeasurementCode = "vV";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
