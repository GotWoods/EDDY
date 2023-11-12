using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPR*XPj*PNnix3*6*X5*8";

		var expected = new CPR_CommodityPriceReference()
		{
			MarketExchangeIdentifier = "XPj",
			Date = "PNnix3",
			UnitPrice = 6,
			CommodityIdentification = "X5",
			YesNoConditionOrResponseCode = "8",
		};

		var actual = Map.MapObject<CPR_CommodityPriceReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XPj", true)]
	public void Validation_RequiredMarketExchangeIdentifier(string marketExchangeIdentifier, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.Date = "PNnix3";
		subject.UnitPrice = 6;
		subject.CommodityIdentification = "X5";
		//Test Parameters
		subject.MarketExchangeIdentifier = marketExchangeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PNnix3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "XPj";
		subject.UnitPrice = 6;
		subject.CommodityIdentification = "X5";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "XPj";
		subject.Date = "PNnix3";
		subject.CommodityIdentification = "X5";
		//Test Parameters
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X5", true)]
	public void Validation_RequiredCommodityIdentification(string commodityIdentification, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "XPj";
		subject.Date = "PNnix3";
		subject.UnitPrice = 6;
		//Test Parameters
		subject.CommodityIdentification = commodityIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
