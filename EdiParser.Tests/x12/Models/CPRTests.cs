using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPR*Pb7*RNvfuO5T*6*uY*d";

		var expected = new CPR_CommodityPriceReference()
		{
			MarketExchangeIdentifierCode = "Pb7",
			Date = "RNvfuO5T",
			UnitPrice = 6,
			CommodityIdentificationCode = "uY",
			YesNoConditionOrResponseCode = "d",
		};

		var actual = Map.MapObject<CPR_CommodityPriceReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pb7", true)]
	public void Validatation_RequiredMarketExchangeIdentifierCode(string marketExchangeIdentifierCode, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		subject.Date = "RNvfuO5T";
		subject.UnitPrice = 6;
		subject.CommodityIdentificationCode = "uY";
		subject.MarketExchangeIdentifierCode = marketExchangeIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RNvfuO5T", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		subject.MarketExchangeIdentifierCode = "Pb7";
		subject.UnitPrice = 6;
		subject.CommodityIdentificationCode = "uY";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validatation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		subject.MarketExchangeIdentifierCode = "Pb7";
		subject.Date = "RNvfuO5T";
		subject.CommodityIdentificationCode = "uY";
		if (unitPrice > 0)
		subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uY", true)]
	public void Validatation_RequiredCommodityIdentificationCode(string commodityIdentificationCode, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		subject.MarketExchangeIdentifierCode = "Pb7";
		subject.Date = "RNvfuO5T";
		subject.UnitPrice = 6;
		subject.CommodityIdentificationCode = commodityIdentificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
