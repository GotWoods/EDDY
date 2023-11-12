using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSS*rE*t9*7*7*5*6*3";

		var expected = new CSS_ConditionalSamplingSequence()
		{
			SamplingSequenceQualifier = "rE",
			UnitOrBasisForMeasurementCode = "t9",
			SamplingSequenceValue = 7,
			SamplingSequenceValue2 = 7,
			SamplingSequenceValue3 = 5,
			SamplingSequenceValue4 = 6,
			SamplingSequenceValue5 = 3,
		};

		var actual = Map.MapObject<CSS_ConditionalSamplingSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rE", true)]
	public void Validation_RequiredSamplingSequenceQualifier(string samplingSequenceQualifier, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "t9";
		subject.SamplingSequenceValue = 7;
		//Test Parameters
		subject.SamplingSequenceQualifier = samplingSequenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t9", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		//Required fields
		subject.SamplingSequenceQualifier = "rE";
		subject.SamplingSequenceValue = 7;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredSamplingSequenceValue(int samplingSequenceValue, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		//Required fields
		subject.SamplingSequenceQualifier = "rE";
		subject.UnitOrBasisForMeasurementCode = "t9";
		//Test Parameters
		if (samplingSequenceValue > 0) 
			subject.SamplingSequenceValue = samplingSequenceValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
