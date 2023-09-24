using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G05*7*8P*6*f8*9*cd*3*of";

		var expected = new G05_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 7,
			UnitOrBasisForMeasurementCode = "8P",
			Weight = 6,
			UnitOrBasisForMeasurementCode2 = "f8",
			Volume = 9,
			UnitOrBasisForMeasurementCode3 = "cd",
			LadingQuantity = 3,
			UnitOrBasisForMeasurementCode4 = "of",
		};

		var actual = Map.MapObject<G05_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "8P", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "8P", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode2 = "f8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 9;
			subject.UnitOrBasisForMeasurementCode3 = "cd";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.LadingQuantity = 3;
			subject.UnitOrBasisForMeasurementCode4 = "of";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "f8", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "f8", false)]
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
			subject.UnitOrBasisForMeasurementCode = "8P";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 9;
			subject.UnitOrBasisForMeasurementCode3 = "cd";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.LadingQuantity = 3;
			subject.UnitOrBasisForMeasurementCode4 = "of";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "cd", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "cd", false)]
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
			subject.UnitOrBasisForMeasurementCode = "8P";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode2 = "f8";
		}
		//If one is filled, all are required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.LadingQuantity = 3;
			subject.UnitOrBasisForMeasurementCode4 = "of";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "of", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "of", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "8P";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode2 = "f8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 9;
			subject.UnitOrBasisForMeasurementCode3 = "cd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
