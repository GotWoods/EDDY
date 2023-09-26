using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NF3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF3**7*Fm*WZ";

		var expected = new NF3_ServingsPerContainerStatement()
		{
			CompositeMultipleLanguageTextInformation = null,
			MeasurementValue = 7,
			UnitOrBasisForMeasurementCode = "Fm",
			MeasurementSignificanceCode = "WZ",
		};

		var actual = Map.MapObject<NF3_ServingsPerContainerStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMultipleLanguageTextInformation(string compositeMultipleLanguageTextInformation, bool isValidExpected)
	{
		var subject = new NF3_ServingsPerContainerStatement();
		//Required fields
		//Test Parameters
		if (compositeMultipleLanguageTextInformation != "") 
			subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue = 7;
			subject.UnitOrBasisForMeasurementCode = "Fm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Fm", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Fm", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF3_ServingsPerContainerStatement();
		//Required fields
		subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
