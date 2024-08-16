using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E211Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "T:u:7:z";

		var expected = new E211_Dimensions()
		{
			MeasurementUnitCode = "T",
			LengthDimension = "u",
			WidthDimension = "7",
			HeightDimension = "z",
		};

		var actual = Map.MapComposite<E211_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new E211_Dimensions();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
