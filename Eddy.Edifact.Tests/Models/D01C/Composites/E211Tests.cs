using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E211Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "8:G:6:8";

		var expected = new E211_Dimensions()
		{
			MeasurementUnitCode = "8",
			LengthMeasure = "G",
			WidthMeasure = "6",
			HeightMeasure = "8",
		};

		var actual = Map.MapComposite<E211_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new E211_Dimensions();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
