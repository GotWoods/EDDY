using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MEA+h+++H";

		var expected = new MEA_Measurements()
		{
			MeasurementAttributeCode = "h",
			MeasurementDetails = null,
			ValueRange = null,
			SurfaceOrLayerCode = "H",
		};

		var actual = Map.MapObject<MEA_Measurements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredMeasurementAttributeCode(string measurementAttributeCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementAttributeCode = measurementAttributeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
