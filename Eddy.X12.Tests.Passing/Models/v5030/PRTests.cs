using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR*r*k*3*r*v*3N*v*V*Rp";

		var expected = new PR_ProductCommodity()
		{
			CommodityGeographicLogicalConnectorCode = "r",
			CommodityCodeQualifier = "k",
			CommodityCode = "3",
			CommodityCode2 = "r",
			ChangeTypeCode = "v",
			StandardCarrierAlphaCode = "3N",
			DocketControlNumber = "v",
			DocketIdentification = "V",
			GroupTitle = "Rp",
		};

		var actual = Map.MapObject<PR_ProductCommodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		//Test Parameters
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "3N", false)]
	[InlineData("k", "", true)]
	[InlineData("", "3N", true)]
	public void Validation_OnlyOneOfCommodityCodeQualifier(string commodityCodeQualifier, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "r";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "k", true)]
	[InlineData("3", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "r";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
