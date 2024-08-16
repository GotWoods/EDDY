using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LOC+z++++w";

		var expected = new LOC_PlaceLocationIdentification()
		{
			PlaceLocationQualifier = "z",
			LocationIdentification = null,
			RelatedLocationOneIdentification = null,
			RelatedLocationTwoIdentification = null,
			RelationCoded = "w",
		};

		var actual = Map.MapObject<LOC_PlaceLocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredPlaceLocationQualifier(string placeLocationQualifier, bool isValidExpected)
	{
		var subject = new LOC_PlaceLocationIdentification();
		//Required fields
		//Test Parameters
		subject.PlaceLocationQualifier = placeLocationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
