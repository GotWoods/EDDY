using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G05*7*vd*3*Dq*4*82*4*Yv";

		var expected = new G05_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 7,
			UnitOrBasisForMeasurementCode = "vd",
			Weight = 3,
			UnitOrBasisForMeasurementCode2 = "Dq",
			Volume = 4,
			UnitOrBasisForMeasurementCode3 = "82",
			LadingQuantity = 4,
			UnitOrBasisForMeasurementCode4 = "Yv",
		};

		var actual = Map.MapObject<G05_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "vd", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "vd", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Dq";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode3 = "82";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Dq", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Dq", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "vd";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode3 = "82";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "82", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "82", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "vd";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Dq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
