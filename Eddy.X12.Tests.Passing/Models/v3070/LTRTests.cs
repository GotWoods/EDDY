using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LTRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LTR*v*J*7**F*o*X*1*3*s*5*7";

		var expected = new LTR_LaboratoryTestResults()
		{
			CodeListQualifierCode = "v",
			IndustryCode = "J",
			MeasurementValue = 7,
			CompositeUnitOfMeasure = null,
			CodeListQualifierCode2 = "F",
			IndustryCode2 = "o",
			ShipmentStatusCode = "X",
			RangeMinimum = 1,
			RangeMaximum = 3,
			GenderCode = "s",
			RangeMinimum2 = 5,
			RangeMaximum2 = 7,
		};

		var actual = Map.MapObject<LTR_LaboratoryTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.IndustryCode = "J";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "s";
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 5;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 7;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "v";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "s";
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 5;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 7;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "o", true)]
	[InlineData("F", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "v";
		subject.IndustryCode = "J";
		//Test Parameters
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.GenderCode) || !string.IsNullOrEmpty(subject.GenderCode) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.GenderCode = "s";
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum2 = 5;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum2 = 7;
			subject.RangeMinimum = 1;
			subject.RangeMaximum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("s", 1, 3, true)]
	[InlineData("s", 0, 0, false)]
	[InlineData("", 1, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_GenderCode(string genderCode, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "v";
		subject.IndustryCode = "J";
		//Test Parameters
		subject.GenderCode = genderCode;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one, at least one
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 5;
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(5, 1, 3, true)]
	[InlineData(5, 0, 0, false)]
	[InlineData(0, 1, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMinimum2(decimal rangeMinimum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "v";
		subject.IndustryCode = "J";
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
			subject.GenderCode = "s";
		}
		if(subject.RangeMaximum2 > 0 || subject.RangeMaximum2 > 0)
		{
			subject.RangeMaximum2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(7, 1, 3, true)]
	[InlineData(7, 0, 0, false)]
	[InlineData(0, 1, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMaximum2(decimal rangeMaximum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new LTR_LaboratoryTestResults();
		//Required fields
		subject.CodeListQualifierCode = "v";
		subject.IndustryCode = "J";
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
			subject.GenderCode = "s";
		}
		if(subject.RangeMinimum2 > 0 || subject.RangeMinimum2 > 0)
		{
			subject.RangeMinimum2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
