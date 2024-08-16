using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LOC+T++++P";

		var expected = new LOC_PlaceLocationIdentification()
		{
			LocationFunctionCodeQualifier = "T",
			LocationIdentification = null,
			RelatedLocationOneIdentification = null,
			RelatedLocationTwoIdentification = null,
			RelationCode = "P",
		};

		var actual = Map.MapObject<LOC_PlaceLocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredLocationFunctionCodeQualifier(string locationFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new LOC_PlaceLocationIdentification();
		//Required fields
		//Test Parameters
		subject.LocationFunctionCodeQualifier = locationFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
