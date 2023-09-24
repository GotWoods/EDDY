using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class NCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCD*fX*g*b*tP*ya*x*n";

		var expected = new NCD_NonconformanceDescription()
		{
			MeasurementAttributeCode = "fX",
			NonconformanceDeterminationCode = "g",
			AssignedIdentification = "b",
			ProductProcessCharacteristicCode = "tP",
			AssociationQualifierCode = "ya",
			ProductDescriptionCode = "x",
			Description = "n",
		};

		var actual = Map.MapObject<NCD_NonconformanceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fX", true)]
	public void Validation_RequiredMeasurementAttributeCode(string measurementAttributeCode, bool isValidExpected)
	{
		var subject = new NCD_NonconformanceDescription();
		subject.MeasurementAttributeCode = measurementAttributeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
