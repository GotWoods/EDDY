using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class GYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GY*h*m*g*8A*R*T*gd*Q";

		var expected = new GY_Geography()
		{
			GeographyQualifierCode = "h",
			CommodityGeographicLogicalConnectorCode = "m",
			LocationQualifier = "g",
			StateOrProvinceCode = "8A",
			LocationIdentifier = "R",
			LocationIdentifier2 = "T",
			StandardCarrierAlphaCode = "gd",
			ChangeTypeCode = "Q",
		};

		var actual = Map.MapObject<GY_Geography>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
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
		subject.GeographyQualifierCode = "h";
		subject.CommodityGeographicLogicalConnectorCode = commodityGeographicLogicalConnectorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "g", true)]
	[InlineData("R", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "h";
		subject.CommodityGeographicLogicalConnectorCode = "m";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "R", true)]
	[InlineData("T", "", false)]
	[InlineData("", "R", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "h";
		subject.CommodityGeographicLogicalConnectorCode = "m";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
		if (locationIdentifier != "")
			subject.LocationQualifier = "g";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
