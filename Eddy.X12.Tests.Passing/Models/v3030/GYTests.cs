using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class GYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GY*9*O*p*6r*Y*X*eY*h";

		var expected = new GY_Geography()
		{
			GeographyQualifierCode = "9",
			CommodityGeographicLogicalConnectorCode = "O",
			LocationQualifier = "p",
			StateOrProvinceCode = "6r",
			LocationIdentifier = "Y",
			LocationIdentifier2 = "X",
			StandardCarrierAlphaCode = "eY",
			ChangeTypeCode = "h",
		};

		var actual = Map.MapObject<GY_Geography>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = geographyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "p", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "9";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "Y", true)]
	[InlineData("X", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "9";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
		if (locationIdentifier != "")
			subject.LocationQualifier = "p";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
