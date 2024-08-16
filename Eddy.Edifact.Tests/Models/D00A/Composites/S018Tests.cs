using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S018Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:M:U:b";

		var expected = new S018_ScenarioIdentification()
		{
			ScenarioIdentification = "h",
			ScenarioVersionNumber = "M",
			ScenarioReleaseNumber = "U",
			ControllingAgencyCoded = "b",
		};

		var actual = Map.MapComposite<S018_ScenarioIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredScenarioIdentification(string scenarioIdentification, bool isValidExpected)
	{
		var subject = new S018_ScenarioIdentification();
		//Required fields
		//Test Parameters
		subject.ScenarioIdentification = scenarioIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
