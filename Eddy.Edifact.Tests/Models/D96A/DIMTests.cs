using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DIMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DIM+v+";

		var expected = new DIM_Dimensions()
		{
			DimensionQualifier = "v",
			Dimensions = null,
		};

		var actual = Map.MapObject<DIM_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredDimensionQualifier(string dimensionQualifier, bool isValidExpected)
	{
		var subject = new DIM_Dimensions();
		//Required fields
		subject.Dimensions = new C211_Dimensions();
		//Test Parameters
		subject.DimensionQualifier = dimensionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDimensions(string dimensions, bool isValidExpected)
	{
		var subject = new DIM_Dimensions();
		//Required fields
		subject.DimensionQualifier = "v";
		//Test Parameters
		if (dimensions != "") 
			subject.Dimensions = new C211_Dimensions();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
