using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class NCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCD*XY*L*8*37*ny*d*z";

		var expected = new NCD_NonconformanceDescription()
		{
			MeasurementAttributeCode = "XY",
			NonconformanceDeterminationCode = "L",
			AssignedIdentification = "8",
			ProductProcessCharacteristicCode = "37",
			AgencyQualifierCode = "ny",
			ProductDescriptionCode = "d",
			Description = "z",
		};

		var actual = Map.MapObject<NCD_NonconformanceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("XY", "L", true)]
	[InlineData("XY", "", true)]
	[InlineData("", "L", true)]
	public void Validation_AtLeastOneMeasurementAttributeCode(string measurementAttributeCode, string nonconformanceDeterminationCode, bool isValidExpected)
	{
		var subject = new NCD_NonconformanceDescription();
		subject.MeasurementAttributeCode = measurementAttributeCode;
		subject.NonconformanceDeterminationCode = nonconformanceDeterminationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
