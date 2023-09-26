using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LTR*7*F*5*Ik*8*t*y*6*1*z*2*4";

		var expected = new LTR_LaboratoryTestResults()
		{
			CodeListQualifierCode = "7",
			IndustryCode = "F",
			MeasurementValue = 5,
			UnitOrBasisForMeasurementCode = "Ik",
			CodeListQualifierCode2 = "8",
			IndustryCode2 = "t",
			StatusCode = "y",
			RangeMinimum = 6,
			RangeMaximum = 1,
			GenderCode = "z",
			RangeMinimum2 = 2,
			RangeMaximum2 = 4,
		};

		var actual = Map.MapObject<LTR_LaboratoryTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.IndustryCode = "F";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "z";
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 2;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "7";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "z";
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 2;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ik", 5, true)]
	[InlineData("Ik", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "7";
		subject.IndustryCode = "F";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "z";
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 2;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "t", true)]
	[InlineData("8", "", false)]
	[InlineData("", "t", true)]
	public void Validation_ARequiresBCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "7";
		subject.IndustryCode = "F";
		//Test Parameters
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "z";
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 2;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("z", 6, 1, true)]
	[InlineData("z", 0, 0, false)]
	[InlineData("", 6, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_GenderCode(string genderCode, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "7";
		subject.IndustryCode = "F";
		//Test Parameters
		subject.GenderCode = genderCode;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one, at least one
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(2, 6, 1, true)]
	[InlineData(2, 0, 0, false)]
	[InlineData(0, 6, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMinimum2(decimal rangeMinimum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "7";
		subject.IndustryCode = "F";
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
			subject.GenderCode = "z";
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(4, 6, 1, true)]
	[InlineData(4, 0, 0, false)]
	[InlineData(0, 6, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMaximum2(decimal rangeMaximum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "7";
		subject.IndustryCode = "F";
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
			subject.GenderCode = "z";
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
