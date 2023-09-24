using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NF4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF4*p*1*47";

		var expected = new NF4_NutritionFactsPanelCalorie()
		{
			MeasurementQualifier = "p",
			MeasurementValue = 1,
			UnitOrBasisForMeasurementCode = "47",
		};

		var actual = Map.MapObject<NF4_NutritionFactsPanelCalorie>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new NF4_NutritionFactsPanelCalorie();
		subject.MeasurementValue = 1;
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new NF4_NutritionFactsPanelCalorie();
		subject.MeasurementQualifier = "p";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
