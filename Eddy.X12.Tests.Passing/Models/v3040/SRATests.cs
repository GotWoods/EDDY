using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRA*Ne*6";

		var expected = new SRA_TrafficEvaluationFactors()
		{
			UnitOrBasisForMeasurementCode = "Ne",
			MeasurementValue = 6,
		};

		var actual = Map.MapObject<SRA_TrafficEvaluationFactors>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ne", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SRA_TrafficEvaluationFactors();
		//Required fields
		subject.MeasurementValue = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new SRA_TrafficEvaluationFactors();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ne";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
