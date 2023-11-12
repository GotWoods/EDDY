using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSS*LP**1*7*3*7*4";

		var expected = new CSS_ConditionalSamplingSequence()
		{
			SamplingSequenceQualifier = "LP",
			CompositeUnitOfMeasure = null,
			SamplingSequenceValue = 1,
			SamplingSequenceValue2 = 7,
			SamplingSequenceValue3 = 3,
			SamplingSequenceValue4 = 7,
			SamplingSequenceValue5 = 4,
		};

		var actual = Map.MapObject<CSS_ConditionalSamplingSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LP", true)]
	public void Validation_RequiredSamplingSequenceQualifier(string samplingSequenceQualifier, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.SamplingSequenceValue = 1;
		//Test Parameters
		subject.SamplingSequenceQualifier = samplingSequenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		//Required fields
		subject.SamplingSequenceQualifier = "LP";
		subject.SamplingSequenceValue = 1;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredSamplingSequenceValue(int samplingSequenceValue, bool isValidExpected)
	{
		var subject = new CSS_ConditionalSamplingSequence();
		//Required fields
		subject.SamplingSequenceQualifier = "LP";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (samplingSequenceValue > 0) 
			subject.SamplingSequenceValue = samplingSequenceValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
