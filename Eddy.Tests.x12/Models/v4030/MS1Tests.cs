using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class MS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS1*qW*rh*eg*AFIWy40*P18a968*w*g*aDI";

		var expected = new MS1_EquipmentShipmentOrRealPropertyLocation()
		{
			CityName = "qW",
			StateOrProvinceCode = "rh",
			CountryCode = "eg",
			LongitudeCode = "AFIWy40",
			LatitudeCode = "P18a968",
			DirectionIdentifierCode = "w",
			DirectionIdentifierCode2 = "g",
			PostalCode = "aDI",
		};

		var actual = Map.MapObject<MS1_EquipmentShipmentOrRealPropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qW", "AFIWy40", false)]
	[InlineData("qW", "", true)]
	[InlineData("", "AFIWy40", true)]
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
			subject.LongitudeCode = "AFIWy40";
			subject.LatitudeCode = "P18a968";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("qW", "rh", "eg", true)]
	[InlineData("qW", "", "", false)]
	[InlineData("", "rh", "eg", true)]
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
			subject.CityName = "qW";
		if (countryCode != "")
			subject.CityName = "qW";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "AFIWy40";
			subject.LatitudeCode = "P18a968";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rh", "qW", true)]
	[InlineData("rh", "", false)]
	[InlineData("", "qW", true)]
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
			subject.LongitudeCode = "AFIWy40";
			subject.LatitudeCode = "P18a968";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "eg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eg", "qW", true)]
	[InlineData("eg", "", false)]
	[InlineData("", "qW", true)]
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
			subject.LongitudeCode = "AFIWy40";
			subject.LatitudeCode = "P18a968";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.StateOrProvinceCode = "rh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AFIWy40", "P18a968", true)]
	[InlineData("AFIWy40", "", false)]
	[InlineData("", "P18a968", false)]
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
			subject.CityName = "qW";
			subject.StateOrProvinceCode = "rh";
			subject.CountryCode = "eg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "AFIWy40", true)]
	[InlineData("w", "", false)]
	[InlineData("", "AFIWy40", true)]
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
			subject.LongitudeCode = "AFIWy40";
			subject.LatitudeCode = "P18a968";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "qW";
			subject.StateOrProvinceCode = "rh";
			subject.CountryCode = "eg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "P18a968", true)]
	[InlineData("g", "", false)]
	[InlineData("", "P18a968", true)]
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
			subject.LongitudeCode = "AFIWy40";
			subject.LatitudeCode = "P18a968";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "qW";
			subject.StateOrProvinceCode = "rh";
			subject.CountryCode = "eg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aDI", "qW", true)]
	[InlineData("aDI", "", false)]
	[InlineData("", "qW", true)]
	public void Validation_ARequiresBPostalCode(string postalCode, string cityName, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.PostalCode = postalCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "AFIWy40";
			subject.LatitudeCode = "P18a968";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.StateOrProvinceCode = "rh";
			subject.CountryCode = "eg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
