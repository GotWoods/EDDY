using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMA*1*g*vK*LT*xIZ*gOYNVx";

		var expected = new SMA_StationAddress()
		{
			AddressTypeCode = "1",
			AddressInformation = "g",
			CityName = "vK",
			StateOrProvinceCode = "LT",
			PostalCode = "xIZ",
			Date = "gOYNVx",
		};

		var actual = Map.MapObject<SMA_StationAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredAddressTypeCode(string addressTypeCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressInformation = "g";
		subject.CityName = "vK";
		subject.StateOrProvinceCode = "LT";
		subject.PostalCode = "xIZ";
		subject.Date = "gOYNVx";
		//Test Parameters
		subject.AddressTypeCode = addressTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "1";
		subject.CityName = "vK";
		subject.StateOrProvinceCode = "LT";
		subject.PostalCode = "xIZ";
		subject.Date = "gOYNVx";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vK", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "1";
		subject.AddressInformation = "g";
		subject.StateOrProvinceCode = "LT";
		subject.PostalCode = "xIZ";
		subject.Date = "gOYNVx";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LT", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "1";
		subject.AddressInformation = "g";
		subject.CityName = "vK";
		subject.PostalCode = "xIZ";
		subject.Date = "gOYNVx";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xIZ", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "1";
		subject.AddressInformation = "g";
		subject.CityName = "vK";
		subject.StateOrProvinceCode = "LT";
		subject.Date = "gOYNVx";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gOYNVx", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "1";
		subject.AddressInformation = "g";
		subject.CityName = "vK";
		subject.StateOrProvinceCode = "LT";
		subject.PostalCode = "xIZ";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
