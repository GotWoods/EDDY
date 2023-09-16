using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SN1*r*8*fl*2*8*w4*B*rw";

		var expected = new SN1_ItemDetailShipment()
		{
			AssignedIdentification = "r",
			NumberOfUnitsShipped = 8,
			UnitOrBasisForMeasurementCode = "fl",
			QuantityShippedToDate = 2,
			QuantityOrdered = 8,
			UnitOrBasisForMeasurementCode2 = "w4",
			ReturnableContainerLoadMakeUpCode = "B",
			LineItemStatusCode = "rw",
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
		subject.UnitOrBasisForMeasurementCode = "fl";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fl", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "w4", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "w4", true)]
	public void Validation_ARequiresBQuantityOrdered(decimal quantityOrdered, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "fl";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
