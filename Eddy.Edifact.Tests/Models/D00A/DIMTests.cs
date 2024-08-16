using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DIMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DIM+m+";

		var expected = new DIM_Dimensions()
		{
			DimensionTypeCodeQualifier = "m",
			Dimensions = null,
		};

		var actual = Map.MapObject<DIM_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredDimensionTypeCodeQualifier(string dimensionTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new DIM_Dimensions();
		//Required fields
		subject.Dimensions = new C211_Dimensions();
		//Test Parameters
		subject.DimensionTypeCodeQualifier = dimensionTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDimensions(string dimensions, bool isValidExpected)
	{
		var subject = new DIM_Dimensions();
		//Required fields
		subject.DimensionTypeCodeQualifier = "m";
		//Test Parameters
		if (dimensions != "") 
			subject.Dimensions = new C211_Dimensions();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
