using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class MS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS1*cD*Lc*XM*uWEBjqp*s6BcZkt*H*E*4Ij*2*5";

		var expected = new MS1_EquipmentShipmentOrRealPropertyLocation()
		{
			CityName = "cD",
			StateOrProvinceCode = "Lc",
			CountryCode = "XM",
			LongitudeCode = "uWEBjqp",
			LatitudeCode = "s6BcZkt",
			DirectionIdentifierCode = "H",
			DirectionIdentifierCode2 = "E",
			PostalCode = "4Ij",
			LongitudeDecimalFormat = 2,
			LatitudeDecimalFormat = 5,
		};

		var actual = Map.MapObject<MS1_EquipmentShipmentOrRealPropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("cD", "Lc", "XM", true)]
	[InlineData("cD", "", "", false)]
	[InlineData("", "Lc", "XM", true)]
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
			subject.CityName = "cD";
		if (countryCode != "")
			subject.CityName = "cD";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "uWEBjqp";
			subject.LatitudeCode = "s6BcZkt";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 2;
			subject.LatitudeDecimalFormat = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "H";
			subject.LongitudeCode = "uWEBjqp";
			subject.LongitudeDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "E";
			subject.LatitudeCode = "s6BcZkt";
			subject.LatitudeDecimalFormat = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lc", "cD", true)]
	[InlineData("Lc", "", false)]
	[InlineData("", "cD", true)]
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
			subject.LongitudeCode = "uWEBjqp";
			subject.LatitudeCode = "s6BcZkt";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 2;
			subject.LatitudeDecimalFormat = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "XM";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "H";
			subject.LongitudeCode = "uWEBjqp";
			subject.LongitudeDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "E";
			subject.LatitudeCode = "s6BcZkt";
			subject.LatitudeDecimalFormat = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XM", "cD", true)]
	[InlineData("XM", "", false)]
	[InlineData("", "cD", true)]
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
			subject.LongitudeCode = "uWEBjqp";
			subject.LatitudeCode = "s6BcZkt";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 2;
			subject.LatitudeDecimalFormat = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.StateOrProvinceCode = "Lc";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "H";
			subject.LongitudeCode = "uWEBjqp";
			subject.LongitudeDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "E";
			subject.LatitudeCode = "s6BcZkt";
			subject.LatitudeDecimalFormat = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uWEBjqp", "s6BcZkt", true)]
	[InlineData("uWEBjqp", "", false)]
	[InlineData("", "s6BcZkt", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string latitudeCode, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.LatitudeCode = latitudeCode;
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 2;
			subject.LatitudeDecimalFormat = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "cD";
			subject.StateOrProvinceCode = "Lc";
			subject.CountryCode = "XM";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "H";
			subject.LongitudeDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "E";
			subject.LatitudeDecimalFormat = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("H", "uWEBjqp", 2, true)]
	[InlineData("H", "", 0, false)]
	[InlineData("", "uWEBjqp", 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode(string directionIdentifierCode, string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "uWEBjqp";
			subject.LatitudeCode = "s6BcZkt";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 2;
			subject.LatitudeDecimalFormat = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "cD";
			subject.StateOrProvinceCode = "Lc";
			subject.CountryCode = "XM";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "E";
			subject.LatitudeCode = "s6BcZkt";
			subject.LatitudeDecimalFormat = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("E", "s6BcZkt", 5, true)]
	[InlineData("E", "", 0, false)]
	[InlineData("", "s6BcZkt", 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode2(string directionIdentifierCode2, string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "uWEBjqp";
			subject.LatitudeCode = "s6BcZkt";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 2;
			subject.LatitudeDecimalFormat = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "cD";
			subject.StateOrProvinceCode = "Lc";
			subject.CountryCode = "XM";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "H";
			subject.LongitudeCode = "uWEBjqp";
			subject.LongitudeDecimalFormat = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4Ij", "cD", true)]
	[InlineData("4Ij", "", false)]
	[InlineData("", "cD", true)]
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
			subject.LongitudeCode = "uWEBjqp";
			subject.LatitudeCode = "s6BcZkt";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 2;
			subject.LatitudeDecimalFormat = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.StateOrProvinceCode = "Lc";
			subject.CountryCode = "XM";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "H";
			subject.LongitudeCode = "uWEBjqp";
			subject.LongitudeDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "E";
			subject.LatitudeCode = "s6BcZkt";
			subject.LatitudeDecimalFormat = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 5, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 5, false)]
	public void Validation_AllAreRequiredLongitudeDecimalFormat(decimal longitudeDecimalFormat, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
		//Required fields
		//Test Parameters
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "uWEBjqp";
			subject.LatitudeCode = "s6BcZkt";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CityName = "cD";
			subject.StateOrProvinceCode = "Lc";
			subject.CountryCode = "XM";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode))
		{
			subject.DirectionIdentifierCode = "H";
			subject.LongitudeCode = "uWEBjqp";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.DirectionIdentifierCode2 = "E";
			subject.LatitudeCode = "s6BcZkt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
