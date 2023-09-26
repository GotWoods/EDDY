using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRO*3*mH*2";

		var expected = new PRO_ProtectiveServiceInformation()
		{
			Temperature = 3,
			UnitOrBasisForMeasurementCode = "mH",
			Percent = 2,
		};

		var actual = Map.MapObject<PRO_ProtectiveServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "mH", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "mH", false)]
	public void Validation_AllAreRequiredTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
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
