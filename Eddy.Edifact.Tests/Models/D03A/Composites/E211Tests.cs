using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E211Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:o:9:X";

		var expected = new E211_Dimensions()
		{
			MeasurementUnitCode = "4",
			LengthMeasure = "o",
			WidthMeasure = "9",
			HeightMeasure = "X",
		};

		var actual = Map.MapComposite<E211_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new E211_Dimensions();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
