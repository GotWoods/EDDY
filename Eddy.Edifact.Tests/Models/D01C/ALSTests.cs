using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class ALSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALS+b++h+E";

		var expected = new ALS_AdditionalLocationInformation()
		{
			LocationFunctionCodeQualifier = "b",
			Location = null,
			LatitudeDegree = "h",
			LongitudeDegree = "E",
		};

		var actual = Map.MapObject<ALS_AdditionalLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredLocationFunctionCodeQualifier(string locationFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new ALS_AdditionalLocationInformation();
		//Required fields
		subject.Location = new E975_Location();
		//Test Parameters
		subject.LocationFunctionCodeQualifier = locationFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredLocation(string location, bool isValidExpected)
	{
		var subject = new ALS_AdditionalLocationInformation();
		//Required fields
		subject.LocationFunctionCodeQualifier = "b";
		//Test Parameters
		if (location != "") 
			subject.Location = new E975_Location();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
