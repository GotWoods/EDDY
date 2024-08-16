using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TMP+n+";

		var expected = new TMP_Temperature()
		{
			TemperatureTypeCodeQualifier = "n",
			TemperatureSetting = null,
		};

		var actual = Map.MapObject<TMP_Temperature>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTemperatureTypeCodeQualifier(string temperatureTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new TMP_Temperature();
		//Required fields
		//Test Parameters
		subject.TemperatureTypeCodeQualifier = temperatureTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
