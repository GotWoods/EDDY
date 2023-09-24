using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RAFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAF*m*qg*N*1*M*2*2*W*1";

		var expected = new RAF_RateAdjustmentFactor()
		{
			CommodityGeographicLogicalConnectorCode = "m",
			RateValueQualifier = "qg",
			ChangeTypeCode = "N",
			Percent = 1,
			RoundingRuleCode = "M",
			FactorAmount = 2,
			ReferenceNumber = "2",
			RateAdjustmentDescriptionCode = "W",
			RateLevel = "1",
		};

		var actual = Map.MapObject<RAF_RateAdjustmentFactor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.RateValueQualifier = "qg";
		subject.ChangeTypeCode = "N";
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qg", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "m";
		subject.ChangeTypeCode = "N";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "m";
		subject.RateValueQualifier = "qg";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "M", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "M", true)]
	public void Validation_ARequiresBPercent(decimal percent, string roundingRuleCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "m";
		subject.RateValueQualifier = "qg";
		subject.ChangeTypeCode = "N";
		if (percent > 0)
			subject.Percent = percent;
		subject.RoundingRuleCode = roundingRuleCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
