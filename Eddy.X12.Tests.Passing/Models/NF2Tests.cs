using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class NF2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF2**2*qv*BB*8*xs*Mf";

		var expected = new NF2_ServingSizeStatement()
		{
			CompositeMultipleLanguageTextInformation = null,
			MeasurementValue = 2,
			UnitOrBasisForMeasurementCode = "qv",
			MeasurementSignificanceCode = "BB",
			MeasurementValue2 = 8,
			UnitOrBasisForMeasurementCode2 = "xs",
			MeasurementSignificanceCode2 = "Mf",
		};

		var actual = Map.MapObject<NF2_ServingSizeStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeMultipleLanguageTextInformation(string compositeMultipleLanguageTextInformation, bool isValidExpected)
	{
		var subject = new NF2_ServingSizeStatement();
		if (compositeMultipleLanguageTextInformation != "")
			subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation() { FreeFormMessageText = compositeMultipleLanguageTextInformation };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "qv", true)]
	[InlineData(0, "qv", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF2_ServingSizeStatement();
		subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "xs", true)]
	[InlineData(0, "xs", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredMeasurementValue2(decimal measurementValue2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new NF2_ServingSizeStatement();
		subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		if (measurementValue2 > 0)
		subject.MeasurementValue2 = measurementValue2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
