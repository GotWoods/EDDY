using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class TRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRT*I1*zL*q**bb*i*7*";

		var expected = new TRT_TradeItemType()
		{
			ClassOfTradeCode = "I1",
			ReferenceIdentificationQualifier = "zL",
			ReferenceIdentification = "q",
			CompositeIngredientInformation = new C068_CompositeIngredientInformation(),
			ReferenceIdentificationQualifier2 = "bb",
			ReferenceIdentification2 = "i",
			MeasurementValue = 7,
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure(),
		};

		var actual = Map.MapObject<TRT_TradeItemType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I1", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		subject.ReferenceIdentificationQualifier = "zL";
		subject.ReferenceIdentification = "q";
		subject.ClassOfTradeCode = classOfTradeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zL", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		subject.ClassOfTradeCode = "I1";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		subject.ClassOfTradeCode = "I1";
		subject.ReferenceIdentificationQualifier = "zL";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("bb", "i", true)]
	[InlineData("", "i", false)]
	[InlineData("bb", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		subject.ClassOfTradeCode = "I1";
		subject.ReferenceIdentificationQualifier = "zL";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		subject.ClassOfTradeCode = "I1";
		subject.ReferenceIdentificationQualifier = "zL";
		subject.ReferenceIdentification = "q";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
        

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
