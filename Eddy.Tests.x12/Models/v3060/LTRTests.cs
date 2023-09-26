using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LTR*W*n*3*vs*j*G*n*1*2*T*1*4";

		var expected = new LTR_LaboratoryTestResults()
		{
			CodeListQualifierCode = "W",
			IndustryCode = "n",
			MeasurementValue = 3,
			UnitOrBasisForMeasurementCode = "vs",
			CodeListQualifierCode2 = "j",
			IndustryCode2 = "G",
			StatusCode = "n",
			RangeMinimum = 1,
			RangeMaximum = 2,
			GenderCode = "T",
			RangeMinimum2 = 1,
			RangeMaximum2 = 4,
		};

		var actual = Map.MapObject<LTR_LaboratoryTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.IndustryCode = "n";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "T";
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 1;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "W";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "T";
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 1;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("vs", 3, true)]
	[InlineData("vs", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "W";
		subject.IndustryCode = "n";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "T";
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 1;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "G", true)]
	[InlineData("j", "", false)]
	[InlineData("", "G", true)]
	public void Validation_ARequiresBCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "W";
		subject.IndustryCode = "n";
		//Test Parameters
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "T";
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 1;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 4;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("T", 1, 2, true)]
	[InlineData("T", 0, 0, false)]
	[InlineData("", 1, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_GenderCode(string genderCode, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "W";
		subject.IndustryCode = "n";
		//Test Parameters
		subject.GenderCode = genderCode;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one, at least one
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 1;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(1, 1, 2, true)]
	[InlineData(1, 0, 0, false)]
	[InlineData(0, 1, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMinimum2(decimal rangeMinimum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "W";
		subject.IndustryCode = "n";
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
			subject.GenderCode = "T";
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(4, 1, 2, true)]
	[InlineData(4, 0, 0, false)]
	[InlineData(0, 1, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMaximum2(decimal rangeMaximum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "W";
		subject.IndustryCode = "n";
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
			subject.GenderCode = "T";
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
