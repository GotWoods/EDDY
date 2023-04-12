using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPD*D*q*Q*w";

		var expected = new TPD_TradingPartnerDetail()
		{
			ItemDescriptionTypeCode = "D",
			CommodityCodeQualifier = "q",
			CommodityCode = "Q",
			Description = "w",
		};

		var actual = Map.MapObject<TPD_TradingPartnerDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new TPD_TradingPartnerDetail();
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("q", "Q", true)]
	[InlineData("", "Q", false)]
	[InlineData("q", "", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TPD_TradingPartnerDetail();
		subject.ItemDescriptionTypeCode = "D";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
