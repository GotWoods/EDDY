using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class TRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRD*M*3u*r*1Y*4";

		var expected = new TRD_TradeItemIngredientDetails()
		{
			MeasurementQualifier = "M",
			ReferenceIdentificationQualifier = "3u",
			ReferenceIdentification = "r",
			UnitOrBasisForMeasurementCode = "1Y",
			MeasurementValue = 4,
		};

		var actual = Map.MapObject<TRD_TradeItemIngredientDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredMeasurementQualifier(string measurementQualifier, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		subject.ReferenceIdentificationQualifier = "3u";
		subject.ReferenceIdentification = "r";
		subject.UnitOrBasisForMeasurementCode = "1Y";
		subject.MeasurementValue = 4;
		//Test Parameters
		subject.MeasurementQualifier = measurementQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3u", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		subject.MeasurementQualifier = "M";
		subject.ReferenceIdentification = "r";
		subject.UnitOrBasisForMeasurementCode = "1Y";
		subject.MeasurementValue = 4;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		subject.MeasurementQualifier = "M";
		subject.ReferenceIdentificationQualifier = "3u";
		subject.UnitOrBasisForMeasurementCode = "1Y";
		subject.MeasurementValue = 4;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1Y", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		subject.MeasurementQualifier = "M";
		subject.ReferenceIdentificationQualifier = "3u";
		subject.ReferenceIdentification = "r";
		subject.MeasurementValue = 4;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new TRD_TradeItemIngredientDetails();
		//Required fields
		subject.MeasurementQualifier = "M";
		subject.ReferenceIdentificationQualifier = "3u";
		subject.ReferenceIdentification = "r";
		subject.UnitOrBasisForMeasurementCode = "1Y";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
