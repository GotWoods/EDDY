using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LOC+Z++++o";

		var expected = new LOC_PlaceLocationIdentification()
		{
			LocationFunctionCodeQualifier = "Z",
			LocationIdentification = null,
			RelatedLocationOneIdentification = null,
			RelatedLocationTwoIdentification = null,
			RelationCoded = "o",
		};

		var actual = Map.MapObject<LOC_PlaceLocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredLocationFunctionCodeQualifier(string locationFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new LOC_PlaceLocationIdentification();
		//Required fields
		//Test Parameters
		subject.LocationFunctionCodeQualifier = locationFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
