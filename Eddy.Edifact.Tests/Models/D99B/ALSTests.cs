using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ALSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALS+x+";

		var expected = new ALS_AdditionalLocationInformation()
		{
			LocationFunctionCodeQualifier = "x",
			Location = null,
		};

		var actual = Map.MapObject<ALS_AdditionalLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
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
		subject.LocationFunctionCodeQualifier = "x";
		//Test Parameters
		if (location != "") 
			subject.Location = new E975_Location();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
