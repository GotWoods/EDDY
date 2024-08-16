using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MEA+f+++s";

		var expected = new MEA_Measurements()
		{
			MeasurementAttributeCode = "f",
			MeasurementDetails = null,
			ValueRange = null,
			SurfaceLayerCode = "s",
		};

		var actual = Map.MapObject<MEA_Measurements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredMeasurementAttributeCode(string measurementAttributeCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementAttributeCode = measurementAttributeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
