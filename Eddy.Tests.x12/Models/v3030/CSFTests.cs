using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CSFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSF*mJ*1*6";

		var expected = new CSF_ConditionalSamplingFrequency()
		{
			UnitOrBasisForMeasurementCode = "mJ",
			SampleSelectionModulus = 1,
			SampleFrequencyValuePerUnitOfMeasurementCode = 6,
		};

		var actual = Map.MapObject<CSF_ConditionalSamplingFrequency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mJ", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CSF_ConditionalSamplingFrequency();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 6, false)]
	[InlineData(1, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_OnlyOneOfSampleSelectionModulus(decimal sampleSelectionModulus, int sampleFrequencyValuePerUnitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new CSF_ConditionalSamplingFrequency();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "mJ";
		//Test Parameters
		if (sampleSelectionModulus > 0) 
			subject.SampleSelectionModulus = sampleSelectionModulus;
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0) 
			subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
