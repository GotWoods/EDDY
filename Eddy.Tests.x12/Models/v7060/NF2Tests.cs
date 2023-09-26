using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NF2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF2**8*Qj*7g*4*Gd*nH";

		var expected = new NF2_ServingSizeStatement()
		{
			CompositeMultipleLanguageTextInformation = null,
			MeasurementValue = 8,
			UnitOrBasisForMeasurementCode = "Qj",
			MeasurementSignificanceCode = "7g",
			MeasurementValue2 = 4,
			UnitOrBasisForMeasurementCode2 = "Gd",
			MeasurementSignificanceCode2 = "nH",
		};

		var actual = Map.MapObject<NF2_ServingSizeStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMultipleLanguageTextInformation(string compositeMultipleLanguageTextInformation, bool isValidExpected)
	{
		var subject = new NF2_ServingSizeStatement();
		//Required fields
		//Test Parameters
		if (compositeMultipleLanguageTextInformation != "") 
			subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue = 8;
			subject.UnitOrBasisForMeasurementCode = "Qj";
		}
		if(subject.MeasurementValue2 > 0 || subject.MeasurementValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.MeasurementValue2 = 4;
			subject.UnitOrBasisForMeasurementCode2 = "Gd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Qj", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Qj", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF2_ServingSizeStatement();
		//Required fields
		subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.MeasurementValue2 > 0 || subject.MeasurementValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.MeasurementValue2 = 4;
			subject.UnitOrBasisForMeasurementCode2 = "Gd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Gd", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Gd", false)]
	public void Validation_AllAreRequiredMeasurementValue2(decimal measurementValue2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new NF2_ServingSizeStatement();
		//Required fields
		subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		//Test Parameters
		if (measurementValue2 > 0) 
			subject.MeasurementValue2 = measurementValue2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.MeasurementValue = 8;
			subject.UnitOrBasisForMeasurementCode = "Qj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
