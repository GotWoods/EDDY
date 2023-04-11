using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G05*4*go*3*BU*7*N0*5*Ol";

		var expected = new G05_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 4,
			UnitOrBasisForMeasurementCode = "go",
			Weight = 3,
			UnitOrBasisForMeasurementCode2 = "BU",
			Volume = 7,
			UnitOrBasisForMeasurementCode3 = "N0",
			LadingQuantity = 5,
			UnitOrBasisForMeasurementCode4 = "Ol",
		};

		var actual = Map.MapObject<G05_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "go", true)]
	[InlineData(0, "go", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "BU", true)]
	[InlineData(0, "BU", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "N0", true)]
	[InlineData(0, "N0", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "Ol", true)]
	[InlineData(0, "Ol", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (ladingQuantity > 0)
		subject.LadingQuantity = ladingQuantity;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
