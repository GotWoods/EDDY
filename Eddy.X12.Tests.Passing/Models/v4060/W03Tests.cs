using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class W03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W03*8*8*Nj*5*8b*1*6X";

		var expected = new W03_TotalShipmentInformationWarehouse()
		{
			NumberOfUnitsShipped = 8,
			Weight = 8,
			UnitOrBasisForMeasurementCode = "Nj",
			Volume = 5,
			UnitOrBasisForMeasurementCode2 = "8b",
			LadingQuantity = 1,
			UnitOrBasisForMeasurementCode3 = "6X",
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
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode2 = "8b";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 1;
			subject.UnitOrBasisForMeasurementCode3 = "6X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Nj", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Nj", false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformationWarehouse();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode2 = "8b";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 1;
			subject.UnitOrBasisForMeasurementCode3 = "6X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "8b", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "8b", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformationWarehouse();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 1;
			subject.UnitOrBasisForMeasurementCode3 = "6X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "6X", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "6X", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformationWarehouse();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode2 = "8b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
