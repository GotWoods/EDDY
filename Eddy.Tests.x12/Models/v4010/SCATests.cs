using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCA*A*Y*0S*9*1*5*2";

		var expected = new SCA_StatisticalCategoryAnalysis()
		{
			CodeListQualifierCode = "A",
			IndustryCode = "Y",
			StatisticCode = "0S",
			Quantity = 9,
			Quantity2 = 1,
			RangeMinimum = 5,
			RangeMaximum = 2,
		};

		var actual = Map.MapObject<SCA_StatisticalCategoryAnalysis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "Y", true)]
	[InlineData("A", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 5;
			subject.RangeMaximum = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.StatisticCode) || !string.IsNullOrEmpty(subject.StatisticCode) || subject.Quantity > 0 || subject.RangeMaximum > 0)
		{
			subject.StatisticCode = "0S";
			subject.Quantity = 9;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("0S", 9, 2, true)]
	[InlineData("0S", 0, 0, false)]
	[InlineData("", 9, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_StatisticCode(string statisticCode, decimal quantity, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		//Required fields
		//Test Parameters
		subject.StatisticCode = statisticCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "A";
			subject.IndustryCode = "Y";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 5;
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 9, true)]
	[InlineData(1, 0, false)]
	[InlineData(0, 9, true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, decimal quantity, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "A";
			subject.IndustryCode = "Y";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 5;
			subject.RangeMaximum = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.StatisticCode) || !string.IsNullOrEmpty(subject.StatisticCode) || subject.RangeMaximum > 0)
		{
			subject.StatisticCode = "0S";
			subject.RangeMaximum = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 2, true)]
	[InlineData(5, 0, false)]
	[InlineData(0, 2, false)]
	public void Validation_AllAreRequiredRangeMinimum(decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		//Required fields
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "A";
			subject.IndustryCode = "Y";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.StatisticCode) || !string.IsNullOrEmpty(subject.StatisticCode) || subject.Quantity > 0)
		{
			subject.StatisticCode = "0S";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
