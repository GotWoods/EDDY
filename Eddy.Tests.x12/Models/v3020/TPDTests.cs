using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPD*z*o*S*Z";

		var expected = new TPD_TradingPartnerDetail()
		{
			ItemDescriptionType = "z",
			CommodityCodeQualifier = "o",
			CommodityCode = "S",
			Description = "Z",
		};

		var actual = Map.MapObject<TPD_TradingPartnerDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new TPD_TradingPartnerDetail();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "o";
			subject.CommodityCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "S", true)]
	[InlineData("o", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TPD_TradingPartnerDetail();
		//Required fields
		subject.ItemDescriptionType = "z";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
