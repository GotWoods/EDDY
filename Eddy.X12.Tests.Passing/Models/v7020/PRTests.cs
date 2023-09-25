using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class PRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR*1*b*F*i*j*vl*I*o*4X";

		var expected = new PR_ProductCommodity()
		{
			CommodityGeographicLogicalConnectorCode = "1",
			CommodityCodeQualifier = "b",
			CommodityCode = "F",
			CommodityCode2 = "i",
			ChangeTypeCode = "j",
			StandardCarrierAlphaCode = "vl",
			DocketControlNumber = "I",
			DocketIdentification = "o",
			GroupTitle = "4X",
		};

		var actual = Map.MapObject<PR_ProductCommodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		//Test Parameters
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		//At Least one
		subject.CommodityCodeQualifier = "b";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "b";
			subject.CommodityCode = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "F", true)]
	[InlineData("b", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "1";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

        if (subject.CommodityCodeQualifier == "")
            subject.StandardCarrierAlphaCode = "ABCD";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}


	[Theory]
	[InlineData("b", "", true)]
	[InlineData("", "vl", true)]
	public void Validation_OnlyOneOfCommodityCodeQualifier(string commodityCodeQualifier, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "1";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;

        if (subject.CommodityCodeQualifier != "")
            subject.CommodityCode = "A";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
