using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class PRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR*g*z*E*d*G*He*s*T*9n";

		var expected = new PR_ProductCommodity()
		{
			CommodityGeographicLogicalConnectorCode = "g",
			CommodityCodeQualifier = "z",
			CommodityCode = "E",
			CommodityCode2 = "d",
			ChangeTypeCode = "G",
			StandardCarrierAlphaCode = "He",
			DocketControlNumber = "s",
			DocketIdentification = "T",
			GroupTitle = "9n",
		};

		var actual = Map.MapObject<PR_ProductCommodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		//Test Parameters
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		//At Least one
		subject.CommodityCodeQualifier = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "z";
			subject.CommodityCode = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "E", true)]
	[InlineData("z", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "g";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

        if (subject.CommodityCodeQualifier == "") 
            subject.StandardCarrierAlphaCode = "ABCD";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("z", "", true)]
	[InlineData("", "He", true)]
	public void Validation_AtLeastOneCommodityCodeQualifier(string commodityCodeQualifier, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "g";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;

        if (subject.CommodityCodeQualifier != "")
            subject.CommodityCode = "A";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("z", "He", false)]
	[InlineData("z", "", true)]
	[InlineData("", "He", true)]
	public void Validation_OnlyOneOfCommodityCodeQualifier(string commodityCodeQualifier, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PR_ProductCommodity();
		//Required fields
		subject.CommodityGeographicLogicalConnectorCode = "g";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;

        if (subject.CommodityCodeQualifier != "")
            subject.CommodityCode = "A";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
