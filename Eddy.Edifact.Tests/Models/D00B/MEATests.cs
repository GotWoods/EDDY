using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MEA+1+++5";

		var expected = new MEA_Measurements()
		{
			MeasurementPurposeCodeQualifier = "1",
			MeasurementDetails = null,
			ValueRange = null,
			SurfaceOrLayerCode = "5",
		};

		var actual = Map.MapObject<MEA_Measurements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredMeasurementPurposeCodeQualifier(string measurementPurposeCodeQualifier, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementPurposeCodeQualifier = measurementPurposeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
