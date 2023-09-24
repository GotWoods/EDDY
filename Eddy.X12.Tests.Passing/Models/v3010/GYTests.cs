using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class GYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GY*V*m*B*2H*n*q*Os";

		var expected = new GY_Geography()
		{
			GeographyQualifierCode = "V",
			CommodityGeographicLogicalConnectorCode = "m",
			LocationQualifier = "B",
			StateOrProvinceCode = "2H",
			LocationIdentifier = "n",
			LocationIdentifier2 = "q",
			StandardCarrierAlphaCode = "Os",
		};

		var actual = Map.MapObject<GY_Geography>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.CommodityGeographicLogicalConnectorCode = "m";
		subject.GeographyQualifierCode = geographyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredCommodityGeographicLogicalConnectorCode(string commodityGeographicLogicalConnectorCode, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "V";
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
