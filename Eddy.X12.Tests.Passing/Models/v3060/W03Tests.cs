using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class W03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W03*5*2*TE*2*6l*2*bS";

		var expected = new W03_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 5,
			Weight = 2,
			UnitOrBasisForMeasurementCode = "TE",
			Volume = 2,
			UnitOrBasisForMeasurementCode2 = "6l",
			LadingQuantity = 2,
			UnitOrBasisForMeasurementCode3 = "bS",
		};

		var actual = Map.MapObject<W03_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode2 = "6l";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 2;
			subject.UnitOrBasisForMeasurementCode3 = "bS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "TE", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "TE", true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 5;
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode2 = "6l";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 2;
			subject.UnitOrBasisForMeasurementCode3 = "bS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "6l", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "6l", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 5;
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 2;
			subject.UnitOrBasisForMeasurementCode3 = "bS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "bS", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "bS", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 5;
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode2 = "6l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
