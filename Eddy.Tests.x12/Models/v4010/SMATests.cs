using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMA*m*9*YH*zU*RBD";

		var expected = new SMA_StationAddress()
		{
			AddressTypeCode = "m",
			AddressInformation = "9",
			CityName = "YH",
			StateOrProvinceCode = "zU",
			PostalCode = "RBD",
		};

		var actual = Map.MapObject<SMA_StationAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAddressTypeCode(string addressTypeCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressInformation = "9";
		subject.CityName = "YH";
		subject.StateOrProvinceCode = "zU";
		subject.PostalCode = "RBD";
		//Test Parameters
		subject.AddressTypeCode = addressTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "m";
		subject.CityName = "YH";
		subject.StateOrProvinceCode = "zU";
		subject.PostalCode = "RBD";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YH", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "m";
		subject.AddressInformation = "9";
		subject.StateOrProvinceCode = "zU";
		subject.PostalCode = "RBD";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zU", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "m";
		subject.AddressInformation = "9";
		subject.CityName = "YH";
		subject.PostalCode = "RBD";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RBD", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "m";
		subject.AddressInformation = "9";
		subject.CityName = "YH";
		subject.StateOrProvinceCode = "zU";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
