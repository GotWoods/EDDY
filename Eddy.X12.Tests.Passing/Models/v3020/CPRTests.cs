using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPR*Wks*0b8t60*7*l2*a";

		var expected = new CPR_CommodityPriceReference()
		{
			MarketExchangeIdentifier = "Wks",
			Date = "0b8t60",
			UnitPrice = 7,
			CommodityIdentification = "l2",
			YesNoConditionOrResponseCode = "a",
		};

		var actual = Map.MapObject<CPR_CommodityPriceReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wks", true)]
	public void Validation_RequiredMarketExchangeIdentifier(string marketExchangeIdentifier, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.Date = "0b8t60";
		subject.UnitPrice = 7;
		subject.CommodityIdentification = "l2";
		//Test Parameters
		subject.MarketExchangeIdentifier = marketExchangeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0b8t60", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "Wks";
		subject.UnitPrice = 7;
		subject.CommodityIdentification = "l2";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "Wks";
		subject.Date = "0b8t60";
		subject.CommodityIdentification = "l2";
		//Test Parameters
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l2", true)]
	public void Validation_RequiredCommodityIdentification(string commodityIdentification, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "Wks";
		subject.Date = "0b8t60";
		subject.UnitPrice = 7;
		//Test Parameters
		subject.CommodityIdentification = commodityIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
