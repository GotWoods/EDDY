using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G05*9*Wi*8*Tu*8*Ac*1*jI";

		var expected = new G05_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 9,
			UnitOrBasisForMeasurementCode = "Wi",
			Weight = 8,
			UnitOrBasisForMeasurementCode2 = "Tu",
			Volume = 8,
			UnitOrBasisForMeasurementCode3 = "Ac",
			LadingQuantity = 1,
			UnitOrBasisForMeasurementCode4 = "jI",
		};

		var actual = Map.MapObject<G05_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.UnitOrBasisForMeasurementCode = "Wi";
		subject.Weight = 8;
		subject.UnitOrBasisForMeasurementCode2 = "Tu";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "Ac";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wi", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 9;
		subject.Weight = 8;
		subject.UnitOrBasisForMeasurementCode2 = "Tu";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "Ac";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = "Wi";
		subject.UnitOrBasisForMeasurementCode2 = "Tu";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "Ac";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tu", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = "Wi";
		subject.Weight = 8;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "Ac";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Ac", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Ac", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = "Wi";
		subject.Weight = 8;
		subject.UnitOrBasisForMeasurementCode2 = "Tu";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
