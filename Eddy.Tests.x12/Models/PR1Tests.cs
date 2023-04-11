using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PR1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR1*4*c*K*O*6*H*f9*6w*K*h*1*6C*lR";

		var expected = new PR1_PriceRequestParameterList1()
		{
			CommodityCodeQualifier = "4",
			CommodityCode = "c",
			CommodityCode2 = "K",
			LocationQualifier = "O",
			LocationIdentifier = "6",
			LocationIdentifier2 = "H",
			StateOrProvinceCode = "f9",
			StandardCarrierAlphaCode = "6w",
			LocationQualifier2 = "K",
			LocationIdentifier3 = "h",
			LocationIdentifier4 = "1",
			StateOrProvinceCode2 = "6C",
			StandardCarrierAlphaCode2 = "lR",
		};

		var actual = Map.MapObject<PR1_PriceRequestParameterList1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		subject.CommodityCode = "c";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		subject.CommodityCodeQualifier = "4";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("O", "6", true)]
	[InlineData("", "6", false)]
	[InlineData("O", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		subject.CommodityCodeQualifier = "4";
		subject.CommodityCode = "c";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("6","f9", true)]
	[InlineData("", "f9", true)]
	[InlineData("6", "", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		subject.CommodityCodeQualifier = "4";
		subject.CommodityCode = "c";
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("K", "h", true)]
	[InlineData("", "h", false)]
	[InlineData("K", "", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier3, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		subject.CommodityCodeQualifier = "4";
		subject.CommodityCode = "c";
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier3 = locationIdentifier3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("h","6C", true)]
	[InlineData("", "6C", true)]
	[InlineData("h", "", true)]
	public void Validation_AtLeastOneLocationIdentifier3(string locationIdentifier3, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		subject.CommodityCodeQualifier = "4";
		subject.CommodityCode = "c";
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
