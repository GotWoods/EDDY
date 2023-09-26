using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class GR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR2*1R*8*w*5s*Sb*aF*3*uWw7ucyw*0Knu*Dt*RE*X";

		var expected = new GR2_TrainData()
		{
			StandardCarrierAlphaCode = "1R",
			LocationQualifier = "8",
			LocationIdentifier = "w",
			CityName = "5s",
			StateOrProvinceCode = "Sb",
			CountryCode = "aF",
			InterchangeTrainIdentification = "3",
			Date = "uWw7ucyw",
			Time = "0Knu",
			StandardCarrierAlphaCode2 = "Dt",
			StandardCarrierAlphaCode3 = "RE",
			InterchangeTrainIdentification2 = "X",
		};

		var actual = Map.MapObject<GR2_TrainData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1R", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		//Required fields
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.LocationIdentifier = "w";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "8";
			subject.LocationIdentifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5s";
			subject.StateOrProvinceCode = "Sb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "w", true)]
	[InlineData("8", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		//Required fields
		subject.StandardCarrierAlphaCode = "1R";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.CityName = "5s";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5s";
			subject.StateOrProvinceCode = "Sb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("w", "5s", true)]
	[InlineData("w", "", true)]
	[InlineData("", "5s", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		//Required fields
		subject.StandardCarrierAlphaCode = "1R";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "8";
			subject.LocationIdentifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5s";
			subject.StateOrProvinceCode = "Sb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5s", "Sb", true)]
	[InlineData("5s", "", false)]
	[InlineData("", "Sb", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		//Required fields
		subject.StandardCarrierAlphaCode = "1R";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.LocationIdentifier = "w";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "8";
			subject.LocationIdentifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
