using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PR1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR1*U*T*7*5*3*a*vt*VK*5*0*W*Sn*oJ";

		var expected = new PR1_PriceRequestParameterList1()
		{
			CommodityCodeQualifier = "U",
			CommodityCode = "T",
			CommodityCode2 = "7",
			LocationQualifier = "5",
			LocationIdentifier = "3",
			LocationIdentifier2 = "a",
			StateOrProvinceCode = "vt",
			StandardCarrierAlphaCode = "VK",
			LocationQualifier2 = "5",
			LocationIdentifier3 = "0",
			LocationIdentifier4 = "W",
			StateOrProvinceCode2 = "Sn",
			StandardCarrierAlphaCode2 = "oJ",
		};

		var actual = Map.MapObject<PR1_PriceRequestParameterList1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCode = "T";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "U";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "5", true)]
	[InlineData("3", "", false)]
	[InlineData("", "5", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "T";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "5", true)]
	[InlineData("a", "", false)]
	[InlineData("", "5", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "T";
		//Test Parameters
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "5", true)]
	[InlineData("0", "", false)]
	[InlineData("", "5", true)]
	public void Validation_ARequiresBLocationIdentifier3(string locationIdentifier3, string locationQualifier2, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "T";
		//Test Parameters
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "5", true)]
	[InlineData("W", "", false)]
	[InlineData("", "5", true)]
	public void Validation_ARequiresBLocationIdentifier4(string locationIdentifier4, string locationQualifier2, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "T";
		//Test Parameters
		subject.LocationIdentifier4 = locationIdentifier4;
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
