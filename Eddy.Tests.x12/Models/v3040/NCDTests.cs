using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class NCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCD*ja*k*H*jM*ey*V*s";

		var expected = new NCD_NonconformanceDescription()
		{
			MeasurementAttributeCode = "ja",
			NonconformanceDeterminationCode = "k",
			AssignedIdentification = "H",
			ProductProcessCharacteristicCode = "jM",
			AgencyQualifierCode = "ey",
			ProductDescriptionCode = "V",
			Description = "s",
		};

		var actual = Map.MapObject<NCD_NonconformanceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ja", "k", true)]
	[InlineData("ja", "", true)]
	[InlineData("", "k", true)]
	public void Validation_AtLeastOneMeasurementAttributeCode(string measurementAttributeCode, string nonconformanceDeterminationCode, bool isValidExpected)
	{
		var subject = new NCD_NonconformanceDescription();
		subject.MeasurementAttributeCode = measurementAttributeCode;
		subject.NonconformanceDeterminationCode = nonconformanceDeterminationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
