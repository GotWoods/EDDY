using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class GYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GY*O*x*d*9x*P*D*r7*R*8f*2*y*hL*2q*Va*m";

		var expected = new GY_Geography()
		{
			GeographyQualifierCode = "O",
			CommodityGeographicLogicalConnectorCode = "x",
			LocationQualifier = "d",
			StateOrProvinceCode = "9x",
			LocationIdentifier = "P",
			LocationIdentifier2 = "D",
			StandardCarrierAlphaCode = "r7",
			ChangeTypeCode = "R",
			StandardCarrierAlphaCode2 = "8f",
			DocketControlNumber = "2",
			DocketIdentification = "y",
			GroupTitle = "hL",
			StateOrProvinceCode2 = "2q",
			CityName = "Va",
			YesNoConditionOrResponseCode = "m",
		};

		var actual = Map.MapObject<GY_Geography>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = geographyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode2 = "2q";
			subject.CityName = "Va";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "d", true)]
	[InlineData("P", "", false)]
	[InlineData("", "d", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "O";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode2 = "2q";
			subject.CityName = "Va";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "P", true)]
	[InlineData("D", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "O";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
		if (locationIdentifier != "")
			subject.LocationQualifier = "d";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode2 = "2q";
			subject.CityName = "Va";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2q", "Va", true)]
	[InlineData("2q", "", false)]
	[InlineData("", "Va", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode2(string stateOrProvinceCode2, string cityName, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "O";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
