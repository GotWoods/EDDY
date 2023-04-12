using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMA*8*F*OO*4o*fZO";

		var expected = new SMA_StationAddress()
		{
			AddressTypeCode = "8",
			AddressInformation = "F",
			CityName = "OO",
			StateOrProvinceCode = "4o",
			PostalCode = "fZO",
		};

		var actual = Map.MapObject<SMA_StationAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredAddressTypeCode(string addressTypeCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		subject.AddressInformation = "F";
		subject.CityName = "OO";
		subject.StateOrProvinceCode = "4o";
		subject.PostalCode = "fZO";
		subject.AddressTypeCode = addressTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		subject.AddressTypeCode = "8";
		subject.CityName = "OO";
		subject.StateOrProvinceCode = "4o";
		subject.PostalCode = "fZO";
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OO", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		subject.AddressTypeCode = "8";
		subject.AddressInformation = "F";
		subject.StateOrProvinceCode = "4o";
		subject.PostalCode = "fZO";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4o", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		subject.AddressTypeCode = "8";
		subject.AddressInformation = "F";
		subject.CityName = "OO";
		subject.PostalCode = "fZO";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fZO", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		subject.AddressTypeCode = "8";
		subject.AddressInformation = "F";
		subject.CityName = "OO";
		subject.StateOrProvinceCode = "4o";
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
