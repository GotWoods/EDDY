using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TMP+R+";

		var expected = new TMP_Temperature()
		{
			TemperatureQualifier = "R",
			TemperatureSetting = null,
		};

		var actual = Map.MapObject<TMP_Temperature>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredTemperatureQualifier(string temperatureQualifier, bool isValidExpected)
	{
		var subject = new TMP_Temperature();
		//Required fields
		//Test Parameters
		subject.TemperatureQualifier = temperatureQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
