using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR*y*t*Y*H*j*Tg*h*K*TN";

		var expected = new PR_ProductCommodity()
		{
			CommodityGeographicLogicalConnectorCode = "y",
			CommodityCodeQualifier = "t",
			CommodityCode = "Y",
			CommodityCode2 = "H",
			ChangeTypeCode = "j",
			StandardCarrierAlphaCode = "Tg",
			DocketControlNumber = "h",
			DocketIdentification = "K",
			GroupTitle = "TN",
		};

		var actual = Map.MapObject<PR_ProductCommodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("t", "Y", true)]
	[InlineData("", "Y", false)]
	[InlineData("t", "", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		subject.CommodityGeographicLogicalConnectorCode = "y";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("t","Tg", true)]
	[InlineData("", "Tg", true)]
	[InlineData("t", "", true)]
	public void Validation_AtLeastOneCommodityCodeQualifier(string commodityCodeQualifier, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		subject.CommodityGeographicLogicalConnectorCode = "y";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "Tg", false)]
	[InlineData("", "Tg", true)]
	[InlineData("t", "", true)]
	public void Validation_OnlyOneOfCommodityCodeQualifier(string commodityCodeQualifier, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		subject.CommodityGeographicLogicalConnectorCode = "y";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
