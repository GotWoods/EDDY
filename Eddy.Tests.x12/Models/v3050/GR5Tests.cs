using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class GR5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR5*kd*lf*3*wI*UIO";

		var expected = new GR5_LoadingDetails()
		{
			SpecialHandlingCode = "kd",
			SurfaceLayerPositionCode = "lf",
			MeasurementValue = 3,
			UnitOrBasisForMeasurementCode = "wI",
			StatusReasonCode = "UIO",
		};

		var actual = Map.MapObject<GR5_LoadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kd", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new GR5_LoadingDetails();
		//Required fields
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		//At Least one
		subject.SurfaceLayerPositionCode = "lf";
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue = 3;
			subject.UnitOrBasisForMeasurementCode = "wI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("lf", 3, true)]
	[InlineData("lf", 0, true)]
	[InlineData("", 3, true)]
	public void Validation_AtLeastOneSurfaceLayerPositionCode(string surfaceLayerPositionCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new GR5_LoadingDetails();
		//Required fields
		subject.SpecialHandlingCode = "kd";
		//Test Parameters
		subject.SurfaceLayerPositionCode = surfaceLayerPositionCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue = 3;
			subject.UnitOrBasisForMeasurementCode = "wI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "wI", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "wI", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new GR5_LoadingDetails();
		//Required fields
		subject.SpecialHandlingCode = "kd";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.SurfaceLayerPositionCode = "lf";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
