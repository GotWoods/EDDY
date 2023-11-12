using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3030.Composites;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MEA*uo*t*1**5*7*P2*qm*3E*Qe";

		var expected = new MEA_Measurements()
		{
			MeasurementReferenceIDCode = "uo",
			MeasurementQualifier = "t",
			MeasurementValue = 1,
			CompositeUnitOfMeasure = null,
			RangeMinimum = 5,
			RangeMaximum = 7,
			MeasurementSignificanceCode = "P2",
			MeasurementAttributeCode = "qm",
			SurfaceLayerPositionCode = "3E",
			MeasurementMethodOrDevice = "Qe",
		};

		var actual = Map.MapObject<MEA_Measurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "A", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "P2";
			subject.RangeMinimum = 5;
			subject.RangeMaximum = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "A", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "P2";
			subject.MeasurementValue = 1;
			subject.RangeMaximum = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "A", true)]
	[InlineData(7, "", false)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMinimum > 0)
		{
			subject.MeasurementSignificanceCode = "P2";
			subject.MeasurementValue = 1;
			subject.RangeMinimum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("P2", 1, 5, 7, true)]
	[InlineData("P2", 0, 0, 0, false)]
	[InlineData("", 1, 5, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MeasurementSignificanceCode(string measurementSignificanceCode, decimal measurementValue, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementSignificanceCode = measurementSignificanceCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//A Requires B
		if (measurementValue > 0)
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (rangeMinimum > 0)
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (rangeMaximum > 0)
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("qm", 1, false)]
	[InlineData("qm", 0, true)]
	[InlineData("", 1, true)]
	public void Validation_OnlyOneOfMeasurementAttributeCode(string measurementAttributeCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementAttributeCode = measurementAttributeCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//A Requires B
		if (measurementValue > 0)
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "P2";
			subject.RangeMinimum = 5;
			subject.RangeMaximum = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
