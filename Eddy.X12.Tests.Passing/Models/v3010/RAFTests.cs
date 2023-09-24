using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RAFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAF*w*O7*e*7*4*6*q*L*6";

		var expected = new RAF_RateAdjustmentFactor()
		{
			CommodityGeographicLogicalConnectorCode = "w",
			RateValueQualifier = "O7",
			ChangeTypeCode = "e",
			Percent = 7,
			RoundingRuleCode = "4",
			FactorAmount = 6,
			ReferenceNumber = "q",
			RateAdjustmentDescriptionCode = "L",
			RateLevel = "6",
		};

		var actual = Map.MapObject<RAF_RateAdjustmentFactor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.RateValueQualifier = "O7";
		subject.ChangeTypeCode = "e";
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O7", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "w";
		subject.ChangeTypeCode = "e";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RAF_RateAdjustmentFactor();
		subject.CommodityGeographicLogicalConnectorCode = "w";
		subject.RateValueQualifier = "O7";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
