using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;

using Eddy.x12.Models.v3050.Composites;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MEA*lB*M*7**7*6*UX*xk*U3*3r";

		var expected = new MEA_Measurements()
		{
			MeasurementReferenceIDCode = "lB",
			MeasurementQualifier = "M",
			MeasurementValue = 7,
			CompositeUnitOfMeasure = null,
			RangeMinimum = 7,
			RangeMaximum = 6,
			MeasurementSignificanceCode = "UX",
			MeasurementAttributeCode = "xk",
			SurfaceLayerPositionCode = "U3",
			MeasurementMethodOrDevice = "3r",
		};

		var actual = Map.MapObject<MEA_Measurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "A", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "A", true)]
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
			subject.MeasurementSignificanceCode = "UX";
			subject.MeasurementValue = 7;
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "A", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "A", true)]
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
			subject.MeasurementSignificanceCode = "UX";
			subject.MeasurementValue = 7;
			subject.RangeMinimum = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("UX", 7, 7, 6, true)]
	[InlineData("UX", 0, 0, 0, false)]
	[InlineData("", 7, 7, 6, true)]
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
		if (rangeMinimum > 0)
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (rangeMaximum > 0)
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("xk", 7, false)]
	[InlineData("xk", 0, true)]
	[InlineData("", 7, true)]
	public void Validation_OnlyOneOfMeasurementAttributeCode(string measurementAttributeCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementAttributeCode = measurementAttributeCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "UX";
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
