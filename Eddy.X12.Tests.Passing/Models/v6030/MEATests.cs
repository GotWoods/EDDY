using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030.Composites;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MEA*dn*6*6**6*7*gO*5e*9L*6v*e*n";

		var expected = new MEA_Measurements()
		{
			MeasurementReferenceIDCode = "dn",
			MeasurementQualifier = "6",
			MeasurementValue = 6,
			CompositeUnitOfMeasure = null,
			RangeMinimum = 6,
			RangeMaximum = 7,
			MeasurementSignificanceCode = "gO",
			MeasurementAttributeCode = "5e",
			SurfaceLayerPositionCode = "9L",
			MeasurementMethodOrDeviceCode = "6v",
			CodeListQualifierCode = "e",
			IndustryCode = "n",
		};

		var actual = Map.MapObject<MEA_Measurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(6, "", "n", true)]
	[InlineData(6, "", "", false)]
	[InlineData(0, "", "n", true)]
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
			subject.CodeListQualifierCode = "e";
			subject.IndustryCode = "n";
		}
		//If one, at least one
		if(subject.RangeMaximum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum = 7;
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "gO";
			subject.MeasurementValue = 6;
			subject.RangeMaximum = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(7, "", "n", true)]
	[InlineData(7, "", "", false)]
	[InlineData(0, "", "n", true)]
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
			subject.CodeListQualifierCode = "e";
			subject.IndustryCode = "n";
		}
		//If one, at least one
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0)
		{
			subject.RangeMinimum = 6;
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMinimum > 0)
		{
			subject.MeasurementSignificanceCode = "gO";
			subject.MeasurementValue = 6;
			subject.RangeMinimum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("gO", 6, 6, 7, true)]
	[InlineData("gO", 0, 0, 0, false)]
	[InlineData("", 6, 6, 7, true)]
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
			subject.CodeListQualifierCode = "e";
			subject.IndustryCode = "n";
            subject.CodeListQualifierCode = "T";
        }
		//If one, at least one
		if(subject.RangeMinimum > 0 || subject.RangeMinimum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "n";
            subject.CodeListQualifierCode = "T";
        }
		if(subject.RangeMaximum > 0 || subject.RangeMaximum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "n";
            subject.CodeListQualifierCode = "T";
        }
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5e", 6, false)]
	[InlineData("5e", 0, true)]
	[InlineData("", 6, true)]
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
			subject.CodeListQualifierCode = "e";
			subject.IndustryCode = "n";
		}
		//If one, at least one
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMinimum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.RangeMinimum = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "n";
		}
		if(subject.RangeMaximum > 0 || subject.RangeMaximum > 0 || subject.RangeMaximum != null || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.RangeMaximum = 7;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.IndustryCode = "n";
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "gO";
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "n", true)]
	[InlineData("e", "", false)]
	[InlineData("", "n", false)]
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
			subject.RangeMinimum = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(subject.RangeMaximum > 0 || subject.RangeMaximum > 0 || subject.RangeMaximum != null)
		{
			subject.RangeMaximum = 7;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || !string.IsNullOrEmpty(subject.MeasurementSignificanceCode) || subject.MeasurementValue > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.MeasurementSignificanceCode = "gO";
			subject.MeasurementValue = 6;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
