using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LTR*f*4*6*5p*G*9*d*2*2*C*6*1";

		var expected = new LTR_LaboratoryTestResults()
		{
			CodeListQualifierCode = "f",
			IndustryCode = "4",
			MeasurementValue = 6,
			UnitOrBasisForMeasurementCode = "5p",
			CodeListQualifierCode2 = "G",
			IndustryCode2 = "9",
			StatusCode = "d",
			RangeMinimum = 2,
			RangeMaximum = 2,
			GenderCode = "C",
			RangeMinimum2 = 6,
			RangeMaximum2 = 1,
		};

		var actual = Map.MapObject<LTR_LaboratoryTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.IndustryCode = "4";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "C";
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 6;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 1;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "f";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "C";
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 6;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 1;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5p", 6, true)]
	[InlineData("5p", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "f";
		subject.IndustryCode = "4";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "C";
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 6;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 1;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "9", true)]
	[InlineData("G", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "f";
		subject.IndustryCode = "4";
		//Test Parameters
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "C";
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 6;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 1;
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("C", 2, 2, true)]
	[InlineData("C", 0, 0, false)]
	[InlineData("", 2, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_GenderCode(string genderCode, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "f";
		subject.IndustryCode = "4";
		//Test Parameters
		subject.GenderCode = genderCode;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one, at least one
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 6;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(6, 2, 2, true)]
	[InlineData(6, 0, 0, false)]
	[InlineData(0, 2, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMinimum2(decimal rangeMinimum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "f";
		subject.IndustryCode = "4";
		//Test Parameters
		if (rangeMinimum2 > 0) 
			subject.RangeMinimum2 = rangeMinimum2;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode))
		{
			subject.GenderCode = "C";
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(1, 2, 2, true)]
	[InlineData(1, 0, 0, false)]
	[InlineData(0, 2, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMaximum2(decimal rangeMaximum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "f";
		subject.IndustryCode = "4";
		//Test Parameters
		if (rangeMaximum2 > 0) 
			subject.RangeMaximum2 = rangeMaximum2;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode))
		{
			subject.GenderCode = "C";
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
