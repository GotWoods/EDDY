using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W18Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W18*Cf*9*6N";

		var expected = new W18_ProbeTemperatures()
		{
			TemperatureProbeLocationCode = "Cf",
			Temperature = 9,
			UnitOrBasisForMeasurementCode = "6N",
		};

		var actual = Map.MapObject<W18_ProbeTemperatures>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cf", true)]
	public void Validation_RequiredTemperatureProbeLocationCode(string temperatureProbeLocationCode, bool isValidExpected)
	{
		var subject = new W18_ProbeTemperatures();
		subject.Temperature = 9;
		subject.TemperatureProbeLocationCode = temperatureProbeLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredTemperature(decimal temperature, bool isValidExpected)
	{
		var subject = new W18_ProbeTemperatures();
		subject.TemperatureProbeLocationCode = "Cf";
		if (temperature > 0)
		subject.Temperature = temperature;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
