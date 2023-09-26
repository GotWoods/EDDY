using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPR*1lB*wp29VbNO*9*Dy*7";

		var expected = new CPR_CommodityPriceReference()
		{
			MarketExchangeIdentifier = "1lB",
			Date = "wp29VbNO",
			UnitPrice = 9,
			CommodityIdentification = "Dy",
			YesNoConditionOrResponseCode = "7",
		};

		var actual = Map.MapObject<CPR_CommodityPriceReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1lB", true)]
	public void Validation_RequiredMarketExchangeIdentifier(string marketExchangeIdentifier, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.Date = "wp29VbNO";
		subject.UnitPrice = 9;
		subject.CommodityIdentification = "Dy";
		//Test Parameters
		subject.MarketExchangeIdentifier = marketExchangeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wp29VbNO", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "1lB";
		subject.UnitPrice = 9;
		subject.CommodityIdentification = "Dy";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "1lB";
		subject.Date = "wp29VbNO";
		subject.CommodityIdentification = "Dy";
		//Test Parameters
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dy", true)]
	public void Validation_RequiredCommodityIdentification(string commodityIdentification, bool isValidExpected)
	{
		var subject = new CPR_CommodityPriceReference();
		//Required fields
		subject.MarketExchangeIdentifier = "1lB";
		subject.Date = "wp29VbNO";
		subject.UnitPrice = 9;
		//Test Parameters
		subject.CommodityIdentification = commodityIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
