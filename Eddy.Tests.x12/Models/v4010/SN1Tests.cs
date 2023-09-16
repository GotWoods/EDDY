using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SN1*V*9*Kz*6*2*F0*v*vt";

		var expected = new SN1_ItemDetailShipment()
		{
			AssignedIdentification = "V",
			NumberOfUnitsShipped = 9,
			UnitOrBasisForMeasurementCode = "Kz",
			QuantityShippedToDate = 6,
			QuantityOrdered = 2,
			UnitOrBasisForMeasurementCode2 = "F0",
			ReturnableContainerLoadMakeUpCode = "v",
			LineItemStatusCode = "vt",
		};

		var actual = Map.MapObject<SN1_ItemDetailShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.UnitOrBasisForMeasurementCode = "Kz";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityOrdered = 2;
			subject.UnitOrBasisForMeasurementCode2 = "F0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kz", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityOrdered = 2;
			subject.UnitOrBasisForMeasurementCode2 = "F0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "F0", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "F0", false)]
	public void Validation_AllAreRequiredQuantityOrdered(decimal quantityOrdered, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = "Kz";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
