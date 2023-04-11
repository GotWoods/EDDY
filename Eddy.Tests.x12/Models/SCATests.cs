using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCA*p*Q*b5*2*7*2*9";

		var expected = new SCA_StatisticalCategoryAnalysis()
		{
			CodeListQualifierCode = "p",
			IndustryCode = "Q",
			StatisticCode = "b5",
			Quantity = 2,
			Quantity2 = 7,
			RangeMinimum = 2,
			RangeMaximum = 9,
		};

		var actual = Map.MapObject<SCA_StatisticalCategoryAnalysis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("p", "Q", true)]
	[InlineData("", "Q", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("b5", 2, true)]
	[InlineData("",2, true)]
	[InlineData("b5", 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_StatisticCode(string statisticCode, decimal quantity, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		subject.StatisticCode = statisticCode;
		if (quantity > 0)
		subject.Quantity = quantity;
		if (rangeMaximum > 0)
		subject.RangeMaximum = rangeMaximum;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 2, true)]
	[InlineData(7, 0, false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, decimal quantity, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(2, 9, true)]
	[InlineData(0, 9, false)]
	[InlineData(2, 0, false)]
	public void Validation_AllAreRequiredRangeMinimum(decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new SCA_StatisticalCategoryAnalysis();
		if (rangeMinimum > 0)
		subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0)
		subject.RangeMaximum = rangeMaximum;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
