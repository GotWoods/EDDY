using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4040.Composites;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MEA*cg*5*2**3*3*od*kd*sG*Yw*T*6";

		var expected = new MEA_Measurements()
		{
			MeasurementReferenceIDCode = "cg",
			MeasurementQualifier = "5",
			MeasurementValue = 2,
			CompositeUnitOfMeasure = null,
			RangeMinimum = 3,
			RangeMaximum = 3,
			MeasurementSignificanceCode = "od",
			MeasurementAttributeCode = "kd",
			SurfaceLayerPositionCode = "sG",
			MeasurementMethodOrDevice = "Yw",
			CodeListQualifierCode = "T",
			IndustryCode = "6",
		};

		var actual = Map.MapObject<MEA_Measurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(3, "", "6", true)]
	[InlineData(3, "", "", false)]
	[InlineData(0, "", "6", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure, string industryCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "T";
			subject.IndustryCode = "6";
		}
		//If one, at least one
		if(subject.RangeMaximum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "od";
			subject.MeasurementValue = 2;
			subject.RangeMaximum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(3, "", "6", true)]
	[InlineData(3, "", "", false)]
	[InlineData(0, "", "6", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure, string industryCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "T";
			subject.IndustryCode = "6";
		}
		//If one, at least one
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0)
		{
			subject.RangeMinimum = 3;
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMinimum > 0)
		{
			subject.MeasurementSignificanceCode = "od";
			subject.MeasurementValue = 2;
			subject.RangeMinimum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("od", 2, 3, 3, true)]
	[InlineData("od", 0, 0, 0, false)]
	[InlineData("", 2, 3, 3, true)]
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
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "T";
			subject.IndustryCode = "6";
		}
		//If one, at least one
		if(subject.RangeMinimum > 0 || subject.RangeMinimum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "6";
            subject.CodeListQualifierCode = "T";
        }
		if(subject.RangeMaximum > 0 || subject.RangeMaximum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "6";
            subject.CodeListQualifierCode = "T";
        }
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("kd", 2, false)]
	[InlineData("kd", 0, true)]
	[InlineData("", 2, true)]
	public void Validation_OnlyOneOfMeasurementAttributeCode(string measurementAttributeCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.MeasurementAttributeCode = measurementAttributeCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "T";
			subject.IndustryCode = "6";
		}
		//If one, at least one
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMinimum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.RangeMinimum = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "6";
		}
		if(subject.RangeMaximum > 0 || subject.RangeMaximum > 0 || subject.RangeMaximum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.RangeMaximum = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "6";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "od";
			subject.RangeMinimum = 3;
			subject.RangeMaximum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "6", true)]
	[InlineData("T", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new MEA_Measurements();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//If one, at least one
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMinimum != null)
		{
			subject.RangeMinimum = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(subject.RangeMaximum > 0 || subject.RangeMaximum > 0 || subject.RangeMaximum != null)
		{
			subject.RangeMaximum = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "od";
			subject.MeasurementValue = 2;
			subject.RangeMinimum = 3;
			subject.RangeMaximum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
