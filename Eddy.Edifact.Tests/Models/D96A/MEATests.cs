using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MEA+C+++a";

		var expected = new MEA_Measurements()
		{
			MeasurementApplicationQualifier = "C",
			MeasurementDetails = null,
			ValueRange = null,
			SurfaceLayerIndicatorCoded = "a",
		};

		var actual = Map.MapObject<MEA_Measurements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredMeasurementApplicationQualifier(string measurementApplicationQualifier, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementApplicationQualifier = measurementApplicationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
