using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class CSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSS*B6**2*3*1*5*2";

		var expected = new CSS_ConditionalSamplingSequence()
		{
			SamplingSequenceQualifier = "B6",
			CompositeUnitOfMeasure = null,
			SamplingSequenceValue = 2,
			SamplingSequenceValue2 = 3,
			SamplingSequenceValue3 = 1,
			SamplingSequenceValue4 = 5,
			SamplingSequenceValue5 = 2,
		};

		var actual = Map.MapObject<CSS_ConditionalSamplingSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("B6", true)]
	public void Validation_RequiredSamplingSequenceQualifier(string samplingSequenceQualifier, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.SamplingSequenceValue = 2;
		subject.SamplingSequenceQualifier = samplingSequenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		if (compositeUnitOfMeasure != "")
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
		subject.SamplingSequenceQualifier = "B6";
		subject.SamplingSequenceValue = 2;
		
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredSamplingSequenceValue(int samplingSequenceValue, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		subject.SamplingSequenceQualifier = "B6";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (samplingSequenceValue > 0)
		subject.SamplingSequenceValue = samplingSequenceValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}