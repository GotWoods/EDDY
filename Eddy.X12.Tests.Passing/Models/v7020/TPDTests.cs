using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class TPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPD*E*G*M*k";

		var expected = new TPD_TradingPartnerDetail()
		{
			ItemDescriptionTypeCode = "E",
			CommodityCodeQualifier = "G",
			CommodityCode = "M",
			Description = "k",
		};

		var actual = Map.MapObject<TPD_TradingPartnerDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new TPD_TradingPartnerDetail();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "G";
			subject.CommodityCode = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "M", true)]
	[InlineData("G", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TPD_TradingPartnerDetail();
		//Required fields
		subject.ItemDescriptionTypeCode = "E";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
