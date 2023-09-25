using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MEA*lI*f*5*Bt*4*1*Jz*Mc*Vo";

		var expected = new MEA_Measurements()
		{
			MeasurementReferenceIDCode = "lI",
			MeasurementQualifier = "f",
			MeasurementValue = 5,
			UnitOfMeasurementCode = "Bt",
			RangeMinimum = 4,
			RangeMaximum = 1,
			MeasurementSignificanceCode = "Jz",
			MeasurementAttributeCode = "Mc",
			SurfaceLayerPositionCode = "Vo",
		};

		var actual = Map.MapObject<MEA_Measurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Bt", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Bt", true)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "Jz";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Bt", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Bt", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "Jz";
			subject.MeasurementValue = 5;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Bt", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Bt", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMinimum > 0)
		{
			subject.MeasurementSignificanceCode = "Jz";
			subject.MeasurementValue = 5;
			subject.RangeMinimum = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("Jz", 5, 4, 1, true)]
	[InlineData("Jz", 0, 0, 0, false)]
	[InlineData("", 5, 4, 1, true)]
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
			subject.UnitOfMeasurementCode = "Bt";
		if (rangeMinimum > 0)
			subject.UnitOfMeasurementCode = "Bt";
		if (rangeMaximum > 0)
			subject.UnitOfMeasurementCode = "Bt";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Mc", 5, false)]
	[InlineData("Mc", 0, true)]
	[InlineData("", 5, true)]
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
			subject.UnitOfMeasurementCode = "Bt";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "Jz";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
