using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class NCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCD*Az*l*I*kC*2r*7*I";

		var expected = new NCD_NonconformanceDescription()
		{
			MeasurementAttributeCode = "Az",
			NonconformanceDeterminationCode = "l",
			AssignedIdentification = "I",
			ProductProcessCharacteristicCode = "kC",
			AgencyQualifierCode = "2r",
			ProductDescriptionCode = "7",
			Description = "I",
		};

		var actual = Map.MapObject<NCD_NonconformanceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Az", true)]
	public void Validation_RequiredMeasurementAttributeCode(string measurementAttributeCode, bool isValidExpected)
	{
		var subject = new NCD_NonconformanceDescription();
		subject.MeasurementAttributeCode = measurementAttributeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
