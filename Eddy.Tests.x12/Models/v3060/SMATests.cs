using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMA*I*K*Qa*Qg*k1v*07Sxjq";

		var expected = new SMA_StationAddress()
		{
			AddressTypeCode = "I",
			AddressInformation = "K",
			CityName = "Qa",
			StateOrProvinceCode = "Qg",
			PostalCode = "k1v",
			Date = "07Sxjq",
		};

		var actual = Map.MapObject<SMA_StationAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAddressTypeCode(string addressTypeCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressInformation = "K";
		subject.CityName = "Qa";
		subject.StateOrProvinceCode = "Qg";
		subject.PostalCode = "k1v";
		subject.Date = "07Sxjq";
		//Test Parameters
		subject.AddressTypeCode = addressTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "I";
		subject.CityName = "Qa";
		subject.StateOrProvinceCode = "Qg";
		subject.PostalCode = "k1v";
		subject.Date = "07Sxjq";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qa", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "I";
		subject.AddressInformation = "K";
		subject.StateOrProvinceCode = "Qg";
		subject.PostalCode = "k1v";
		subject.Date = "07Sxjq";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qg", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "I";
		subject.AddressInformation = "K";
		subject.CityName = "Qa";
		subject.PostalCode = "k1v";
		subject.Date = "07Sxjq";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k1v", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "I";
		subject.AddressInformation = "K";
		subject.CityName = "Qa";
		subject.StateOrProvinceCode = "Qg";
		subject.Date = "07Sxjq";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("07Sxjq", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "I";
		subject.AddressInformation = "K";
		subject.CityName = "Qa";
		subject.StateOrProvinceCode = "Qg";
		subject.PostalCode = "k1v";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
