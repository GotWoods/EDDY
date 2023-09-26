using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PR1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR1*l*Z*x*1*H*c*xt*Mo*C*p*M*Yu*dZ";

		var expected = new PR1_PriceRequestParameterList1()
		{
			CommodityCodeQualifier = "l",
			CommodityCode = "Z",
			CommodityCode2 = "x",
			LocationQualifier = "1",
			LocationIdentifier = "H",
			LocationIdentifier2 = "c",
			StateOrProvinceCode = "xt",
			StandardCarrierAlphaCode = "Mo",
			LocationQualifier2 = "C",
			LocationIdentifier3 = "p",
			LocationIdentifier4 = "M",
			StateOrProvinceCode2 = "Yu",
			StandardCarrierAlphaCode2 = "dZ",
		};

		var actual = Map.MapObject<PR1_PriceRequestParameterList1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCode = "Z";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "l";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "1", true)]
	[InlineData("H", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "l";
		subject.CommodityCode = "Z";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "1", true)]
	[InlineData("c", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationQualifier, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "l";
		subject.CommodityCode = "Z";
		//Test Parameters
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "C", true)]
	[InlineData("p", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBLocationIdentifier3(string locationIdentifier3, string locationQualifier2, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "l";
		subject.CommodityCode = "Z";
		//Test Parameters
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "C", true)]
	[InlineData("M", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBLocationIdentifier4(string locationIdentifier4, string locationQualifier2, bool isValidExpected)
	{
		var subject = new PR1_PriceRequestParameterList1();
		//Required fields
		subject.CommodityCodeQualifier = "l";
		subject.CommodityCode = "Z";
		//Test Parameters
		subject.LocationIdentifier4 = locationIdentifier4;
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
