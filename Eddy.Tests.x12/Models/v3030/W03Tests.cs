using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W03*6*7*MG*4*jO*6*pA";

		var expected = new W03_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 6,
			Weight = 7,
			UnitOrBasisForMeasurementCode = "MG",
			Volume = 4,
			UnitOrBasisForMeasurementCode2 = "jO",
			LadingQuantity = 6,
			UnitOrBasisForMeasurementCode3 = "pA",
		};

		var actual = Map.MapObject<W03_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.Weight = 7;
		subject.UnitOrBasisForMeasurementCode = "MG";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode2 = "jO";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 6;
			subject.UnitOrBasisForMeasurementCode3 = "pA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 6;
		subject.UnitOrBasisForMeasurementCode = "MG";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode2 = "jO";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 6;
			subject.UnitOrBasisForMeasurementCode3 = "pA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MG", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 6;
		subject.Weight = 7;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode2 = "jO";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 6;
			subject.UnitOrBasisForMeasurementCode3 = "pA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "jO", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "jO", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 6;
		subject.Weight = 7;
		subject.UnitOrBasisForMeasurementCode = "MG";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.LadingQuantity = 6;
			subject.UnitOrBasisForMeasurementCode3 = "pA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "pA", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "pA", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 6;
		subject.Weight = 7;
		subject.UnitOrBasisForMeasurementCode = "MG";
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode2 = "jO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
