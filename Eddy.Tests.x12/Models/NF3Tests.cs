using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class NF3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF3**9*rF*8L";

		var expected = new NF3_ServingsPerContainerStatement()
		{
			CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation(),
			MeasurementValue = 9,
			UnitOrBasisForMeasurementCode = "rF",
			MeasurementSignificanceCode = "8L",
		};

		var actual = Map.MapObject<NF3_ServingsPerContainerStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeMultipleLanguageTextInformation(string compositeMultipleLanguageTextInformation, bool isValidExpected)
	{
		var subject = new NF3_ServingsPerContainerStatement();

		if (compositeMultipleLanguageTextInformation != "")
			subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation() { FreeFormMessageText = compositeMultipleLanguageTextInformation };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "rF", true)]
	[InlineData(0, "rF", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new NF3_ServingsPerContainerStatement();
		subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
