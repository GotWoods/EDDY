using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR*Z*K*T*J*Q*JZ*Y*N*Ni";

		var expected = new PR_ProductCommodity()
		{
			CommodityGeographicLogicalConnectorCode = "Z",
			CommodityCodeQualifier = "K",
			CommodityCode = "T",
			CommodityCode2 = "J",
			ChangeTypeCode = "Q",
			StandardCarrierAlphaCode = "JZ",
			DocketControlNumber = "Y",
			DocketIdentification = "N",
			GroupTitle = "Ni",
		};

		var actual = Map.MapObject<PR_ProductCommodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
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
	[InlineData("T", "K", true)]
	[InlineData("T", "", false)]
	[InlineData("", "K", true)]
	public void Validation_ARequiresBCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "Z";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
