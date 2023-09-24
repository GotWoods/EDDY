using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RAFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAF*B*3z*o*8*x*1*t*Y*d";

		var expected = new RAF_RateAdjustmentFactor()
		{
			CommodityGeographicLogicalConnectorCode = "B",
			RateValueQualifier = "3z",
			ChangeTypeCode = "o",
			Percent = 8,
			RoundingRuleCode = "x",
			FactorAmount = 1,
			ReferenceIdentification = "t",
			RateAdjustmentDescriptionCode = "Y",
			RateLevel = "d",
		};

		var actual = Map.MapObject<RAF_RateAdjustmentFactor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.RateValueQualifier = "3z";
		subject.ChangeTypeCode = "o";
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3z", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "B";
		subject.ChangeTypeCode = "o";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "B";
		subject.RateValueQualifier = "3z";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "x", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBPercent(decimal percent, string roundingRuleCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "B";
		subject.RateValueQualifier = "3z";
		subject.ChangeTypeCode = "o";
		if (percent > 0)
			subject.Percent = percent;
		subject.RoundingRuleCode = roundingRuleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
