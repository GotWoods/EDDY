using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class ALSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALS+I++U+4";

		var expected = new ALS_AdditionalLocationInformation()
		{
			LocationFunctionCodeQualifier = "I",
			Location = null,
			LatitudeValue = "U",
			LongitudeValue = "4",
		};

		var actual = Map.MapObject<ALS_AdditionalLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
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
		subject.LocationFunctionCodeQualifier = "I";
		//Test Parameters
		if (location != "") 
			subject.Location = new E975_Location();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
