using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS1*ui*rz*nb*aMMEGOS*7KFrJvq*p*8";

		var expected = new MS1_EquipmentShipmentOrRealPropertyLocation()
		{
			CityName = "ui",
			StateOrProvinceCode = "rz",
			CountryCode = "nb",
			LongitudeCode = "aMMEGOS",
			LatitudeCode = "7KFrJvq",
			DirectionIdentifierCode = "p",
			DirectionIdentifierCode2 = "8",
		};

		var actual = Map.MapObject<MS1_EquipmentShipmentOrRealPropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ui", "aMMEGOS", false)]
	[InlineData("ui", "", true)]
	[InlineData("", "aMMEGOS", true)]
	public void Validation_OnlyOneOfCityName(string cityName, string longitudeCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.CityName = cityName;
		subject.LongitudeCode = longitudeCode;

        if (subject.CityName != "")
            subject.StateOrProvinceCode = "AB";

        //If one filled, all required
        if (!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "aMMEGOS";
			subject.LatitudeCode = "7KFrJvq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("ui", "rz", "nb", true)]
	[InlineData("ui", "", "", false)]
	[InlineData("", "rz", "nb", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CityName(string cityName, string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CityName = "ui";
		if (countryCode != "")
			subject.CityName = "ui";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "aMMEGOS";
			subject.LatitudeCode = "7KFrJvq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rz", "ui", true)]
	[InlineData("rz", "", false)]
	[InlineData("", "ui", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "aMMEGOS";
			subject.LatitudeCode = "7KFrJvq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "nb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nb", "ui", true)]
	[InlineData("nb", "", false)]
	[InlineData("", "ui", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string cityName, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "aMMEGOS";
			subject.LatitudeCode = "7KFrJvq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.StateOrProvinceCode = "rz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aMMEGOS", "7KFrJvq", true)]
	[InlineData("aMMEGOS", "", false)]
	[InlineData("", "7KFrJvq", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string latitudeCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.LatitudeCode = latitudeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "ui";
			subject.StateOrProvinceCode = "rz";
			subject.CountryCode = "nb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "aMMEGOS", true)]
	[InlineData("p", "", false)]
	[InlineData("", "aMMEGOS", true)]
	public void Validation_ARequiresBDirectionIdentifierCode(string directionIdentifierCode, string longitudeCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.LongitudeCode = longitudeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "aMMEGOS";
			subject.LatitudeCode = "7KFrJvq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "ui";
			subject.StateOrProvinceCode = "rz";
			subject.CountryCode = "nb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "7KFrJvq", true)]
	[InlineData("8", "", false)]
	[InlineData("", "7KFrJvq", true)]
	public void Validation_ARequiresBDirectionIdentifierCode2(string directionIdentifierCode2, string latitudeCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.LatitudeCode = latitudeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "aMMEGOS";
			subject.LatitudeCode = "7KFrJvq";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "ui";
			subject.StateOrProvinceCode = "rz";
			subject.CountryCode = "nb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
