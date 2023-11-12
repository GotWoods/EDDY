using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class GYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GY*K*5*e*rJ*v*9*Oz*I*Mp*9*a*HG*I2*rx*x";

		var expected = new GY_Geography()
		{
			GeographyQualifierCode = "K",
			CommodityGeographicLogicalConnectorCode = "5",
			LocationQualifier = "e",
			StateOrProvinceCode = "rJ",
			LocationIdentifier = "v",
			LocationIdentifier2 = "9",
			StandardCarrierAlphaCode = "Oz",
			ChangeTypeCode = "I",
			StandardCarrierAlphaCode2 = "Mp",
			DocketControlNumber = "9",
			DocketIdentification = "a",
			GroupTitle = "HG",
			StateOrProvinceCode2 = "I2",
			CityName = "rx",
			YesNoConditionOrResponseCode = "x",
		};

		var actual = Map.MapObject<GY_Geography>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = geographyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode2 = "I2";
			subject.CityName = "rx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "Mp", false)]
	[InlineData("e", "", true)]
	[InlineData("", "Mp", true)]
	public void Validation_OnlyOneOfLocationQualifier(string locationQualifier, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "K";
		subject.LocationQualifier = locationQualifier;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode2 = "I2";
			subject.CityName = "rx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "e", true)]
	[InlineData("v", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "K";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode2 = "I2";
			subject.CityName = "rx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "v", true)]
	[InlineData("9", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "K";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
		if (locationIdentifier != "")
			subject.LocationQualifier = "e";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode2 = "I2";
			subject.CityName = "rx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I2", "rx", true)]
	[InlineData("I2", "", false)]
	[InlineData("", "rx", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode2(string stateOrProvinceCode2, string cityName, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "K";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
