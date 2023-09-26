using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class GR5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR5*aH*3h*8*95";

		var expected = new GR5_LoadingDetails()
		{
			SpecialHandlingCode = "aH",
			SurfaceLayerPositionCode = "3h",
			MeasurementValue = 8,
			UnitOrBasisForMeasurementCode = "95",
		};

		var actual = Map.MapObject<GR5_LoadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aH", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new GR5_LoadingDetails();
		//Required fields
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		//At Least one
		subject.SurfaceLayerPositionCode = "3h";
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue = 8;
			subject.UnitOrBasisForMeasurementCode = "95";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("3h", 8, true)]
	[InlineData("3h", 0, true)]
	[InlineData("", 8, true)]
	public void Validation_AtLeastOneSurfaceLayerPositionCode(string surfaceLayerPositionCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new GR5_LoadingDetails();
		//Required fields
		subject.SpecialHandlingCode = "aH";
		//Test Parameters
		subject.SurfaceLayerPositionCode = surfaceLayerPositionCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue = 8;
			subject.UnitOrBasisForMeasurementCode = "95";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "95", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "95", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new GR5_LoadingDetails();
		//Required fields
		subject.SpecialHandlingCode = "aH";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.SurfaceLayerPositionCode = "3h";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
