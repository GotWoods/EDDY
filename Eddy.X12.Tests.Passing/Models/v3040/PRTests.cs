using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR*0*8*f*n*Y*7N*M*C*Gd";

		var expected = new PR_ProductCommodity()
		{
			CommodityGeographicLogicalConnectorCode = "0",
			CommodityCodeQualifier = "8",
			CommodityCode = "f",
			CommodityCode2 = "n",
			ChangeTypeCode = "Y",
			StandardCarrierAlphaCode = "7N",
			DocketControlNumber = "M",
			DocketIdentification = "C",
			GroupTitle = "Gd",
		};

		var actual = Map.MapObject<PR_ProductCommodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
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
	[InlineData("f", "8", true)]
	[InlineData("f", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "0";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
