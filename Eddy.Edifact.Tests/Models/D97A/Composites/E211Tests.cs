using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E211Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:H:y:Q";

		var expected = new E211_Dimensions()
		{
			MeasureUnitQualifier = "D",
			LengthDimension = "H",
			WidthDimension = "y",
			HeightDimension = "Q",
		};

		var actual = Map.MapComposite<E211_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredMeasureUnitQualifier(string measureUnitQualifier, bool isValidExpected)
	{
		var subject = new E211_Dimensions();
		//Required fields
		//Test Parameters
		subject.MeasureUnitQualifier = measureUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
