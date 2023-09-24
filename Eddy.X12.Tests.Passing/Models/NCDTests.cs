using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCD*zi*2*K*mM*Im*6*W";

		var expected = new NCD_NonconformanceDescription()
		{
			MeasurementAttributeCode = "zi",
			NonconformanceDeterminationCode = "2",
			AssignedIdentification = "K",
			ProductProcessCharacteristicCode = "mM",
			AgencyQualifierCode = "Im",
			ProductDescriptionCode = "6",
			Description = "W",
		};

		var actual = Map.MapObject<NCD_NonconformanceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("zi","2", true)]
	[InlineData("", "2", true)]
	[InlineData("zi", "", true)]
	public void Validation_AtLeastOneMeasurementAttributeCode(string measurementAttributeCode, string nonconformanceDeterminationCode, bool isValidExpected)
	{
		var subject = new NCD_NonconformanceDescription();
		subject.MeasurementAttributeCode = measurementAttributeCode;
		subject.NonconformanceDeterminationCode = nonconformanceDeterminationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
