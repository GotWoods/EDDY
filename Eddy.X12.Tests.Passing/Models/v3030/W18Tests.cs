using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W18Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W18*Cl*4*8F";

		var expected = new W18_ProbeTemperatures()
		{
			TemperatureProbeLocationCode = "Cl",
			Temperature = 4,
			UnitOrBasisForMeasurementCode = "8F",
		};

		var actual = Map.MapObject<W18_ProbeTemperatures>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cl", true)]
	public void Validation_RequiredTemperatureProbeLocationCode(string temperatureProbeLocationCode, bool isValidExpected)
	{
		var subject = new W18_ProbeTemperatures();
		//Required fields
		subject.Temperature = 4;
		//Test Parameters
		subject.TemperatureProbeLocationCode = temperatureProbeLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredTemperature(int temperature, bool isValidExpected)
	{
		var subject = new W18_ProbeTemperatures();
		//Required fields
		subject.TemperatureProbeLocationCode = "Cl";
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
