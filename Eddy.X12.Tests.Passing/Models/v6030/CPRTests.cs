using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPR*CmF*WCVaSWeM*2*qe*s";

		var expected = new CPR_CommodityPriceReference()
		{
			MarketExchangeIdentifierCode = "CmF",
			Date = "WCVaSWeM",
			UnitPrice = 2,
			CommodityIdentificationCode = "qe",
			YesNoConditionOrResponseCode = "s",
		};

		var actual = Map.MapObject<CPR_CommodityPriceReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CmF", true)]
	public void Validation_RequiredMarketExchangeIdentifierCode(string marketExchangeIdentifierCode, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.Date = "WCVaSWeM";
		subject.UnitPrice = 2;
		subject.CommodityIdentificationCode = "qe";
		//Test Parameters
		subject.MarketExchangeIdentifierCode = marketExchangeIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WCVaSWeM", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifierCode = "CmF";
		subject.UnitPrice = 2;
		subject.CommodityIdentificationCode = "qe";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifierCode = "CmF";
		subject.Date = "WCVaSWeM";
		subject.CommodityIdentificationCode = "qe";
		//Test Parameters
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qe", true)]
	public void Validation_RequiredCommodityIdentificationCode(string commodityIdentificationCode, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifierCode = "CmF";
		subject.Date = "WCVaSWeM";
		subject.UnitPrice = 2;
		//Test Parameters
		subject.CommodityIdentificationCode = commodityIdentificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
