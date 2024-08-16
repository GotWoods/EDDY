using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class ALSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALS+2+";

		var expected = new ALS_AdditionalLocationInformation()
		{
			PlaceLocationQualifier = "2",
			Location = null,
		};

		var actual = Map.MapObject<ALS_AdditionalLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredPlaceLocationQualifier(string placeLocationQualifier, bool isValidExpected)
	{
		var subject = new ALS_AdditionalLocationInformation();
		//Required fields
		subject.Location = new E975_Location();
		//Test Parameters
		subject.PlaceLocationQualifier = placeLocationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredLocation(string location, bool isValidExpected)
	{
		var subject = new ALS_AdditionalLocationInformation();
		//Required fields
		subject.PlaceLocationQualifier = "2";
		//Test Parameters
		if (location != "") 
			subject.Location = new E975_Location();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
