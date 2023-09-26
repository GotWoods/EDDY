using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRO*7*aK*6";

		var expected = new PRO_ProtectiveServiceInformation()
		{
			Temperature = 7,
			UnitOrBasisForMeasurementCode = "aK",
			Percent = 6,
		};

		var actual = Map.MapObject<PRO_ProtectiveServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "aK", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "aK", false)]
	public void Validation_AllAreRequiredTemperature(int temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PRO_ProtectiveServiceInformation();
		//Required fields
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
