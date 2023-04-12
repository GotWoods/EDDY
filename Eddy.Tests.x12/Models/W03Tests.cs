using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W03*8*6*1w*1*dw*6*aX";

		var expected = new W03_TotalShipmentInformationWarehouse()
		{
			NumberOfUnitsShipped = 8,
			Weight = 6,
			UnitOrBasisForMeasurementCode = "1w",
			Volume = 1,
			UnitOrBasisForMeasurementCode2 = "dw",
			LadingQuantity = 6,
			UnitOrBasisForMeasurementCode3 = "aX",
		};

		var actual = Map.MapObject<W03_TotalShipmentInformationWarehouse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformationWarehouse();
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "1w", true)]
	[InlineData(0, "1w", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformationWarehouse();
		subject.NumberOfUnitsShipped = 8;
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "dw", true)]
	[InlineData(0, "dw", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformationWarehouse();
		subject.NumberOfUnitsShipped = 8;
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "aX", true)]
	[InlineData(0, "aX", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformationWarehouse();
		subject.NumberOfUnitsShipped = 8;
		if (ladingQuantity > 0)
		subject.LadingQuantity = ladingQuantity;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
