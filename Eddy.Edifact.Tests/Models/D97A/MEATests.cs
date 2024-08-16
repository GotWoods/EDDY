using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MEA+B+++S";

		var expected = new MEA_Measurements()
		{
			MeasurementPurposeQualifier = "B",
			MeasurementDetails = null,
			ValueRange = null,
			SurfaceLayerIndicatorCoded = "S",
		};

		var actual = Map.MapObject<MEA_Measurements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredMeasurementPurposeQualifier(string measurementPurposeQualifier, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementPurposeQualifier = measurementPurposeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
