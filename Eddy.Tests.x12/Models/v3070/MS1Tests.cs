using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS1*Pr*lA*NP*N35GM5Q*4SLjUv3";

		var expected = new MS1_EquipmentLocation()
		{
			CityName = "Pr",
			StateOrProvinceCode = "lA",
			CountryCode = "NP",
			LongitudeCode = "N35GM5Q",
			LatitudeCode = "4SLjUv3",
		};

		var actual = Map.MapObject<MS1_EquipmentLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Pr", "N35GM5Q", false)]
	[InlineData("Pr", "", true)]
	[InlineData("", "N35GM5Q", true)]
	public void Validation_OnlyOneOfCityName(string cityName, string longitudeCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentLocation();
		//Required fields
		//Test Parameters
		subject.CityName = cityName;
		subject.LongitudeCode = longitudeCode;

        if (subject.CityName != "")
            subject.StateOrProvinceCode = "AB";

		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "N35GM5Q";
			subject.LatitudeCode = "4SLjUv3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Pr", "lA", "NP", true)]
	[InlineData("Pr", "", "", false)]
	[InlineData("", "lA", "NP", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CityName(string cityName, string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentLocation();
		//Required fields
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CityName = "Pr";
		if (countryCode != "")
			subject.CityName = "Pr";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "N35GM5Q";
			subject.LatitudeCode = "4SLjUv3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lA", "Pr", true)]
	[InlineData("lA", "", false)]
	[InlineData("", "Pr", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new MS1_EquipmentLocation();
		//Required fields
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "N35GM5Q";
			subject.LatitudeCode = "4SLjUv3";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "NP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NP", "Pr", true)]
	[InlineData("NP", "", false)]
	[InlineData("", "Pr", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string cityName, bool isValidExpected)
	{
		var subject = new MS1_EquipmentLocation();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "N35GM5Q";
			subject.LatitudeCode = "4SLjUv3";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.StateOrProvinceCode = "lA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N35GM5Q", "4SLjUv3", true)]
	[InlineData("N35GM5Q", "", false)]
	[InlineData("", "4SLjUv3", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string latitudeCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentLocation();
		//Required fields
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.LatitudeCode = latitudeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "Pr";
			subject.StateOrProvinceCode = "lA";
			subject.CountryCode = "NP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
