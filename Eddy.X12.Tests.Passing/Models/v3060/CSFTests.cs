using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CSFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSF**8*2";

		var expected = new CSF_ConditionalSamplingFrequency()
		{
			CompositeUnitOfMeasure = null,
			SampleSelectionModulus = 8,
			SampleFrequencyValuePerUnitOfMeasurementCode = 2,
		};

		var actual = Map.MapObject<CSF_ConditionalSamplingFrequency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new CSF_ConditionalSamplingFrequency();
		//Required fields
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 2, false)]
	[InlineData(8, 0, true)]
	[InlineData(0, 2, true)]
	public void Validation_OnlyOneOfSampleSelectionModulus(decimal sampleSelectionModulus, int sampleFrequencyValuePerUnitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new CSF_ConditionalSamplingFrequency();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (sampleSelectionModulus > 0) 
			subject.SampleSelectionModulus = sampleSelectionModulus;
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0) 
			subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
