using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMA*4*O*ig*Ek*lft*E8NInC";

		var expected = new SMA_StationAddress()
		{
			AddressTypeCode = "4",
			AddressInformation = "O",
			CityName = "ig",
			StateOrProvinceCode = "Ek",
			PostalCode = "lft",
			Date = "E8NInC",
		};

		var actual = Map.MapObject<SMA_StationAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredAddressTypeCode(string addressTypeCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressInformation = "O";
		subject.CityName = "ig";
		subject.StateOrProvinceCode = "Ek";
		subject.PostalCode = "lft";
		subject.Date = "E8NInC";
		//Test Parameters
		subject.AddressTypeCode = addressTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "4";
		subject.CityName = "ig";
		subject.StateOrProvinceCode = "Ek";
		subject.PostalCode = "lft";
		subject.Date = "E8NInC";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ig", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "4";
		subject.AddressInformation = "O";
		subject.StateOrProvinceCode = "Ek";
		subject.PostalCode = "lft";
		subject.Date = "E8NInC";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ek", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "4";
		subject.AddressInformation = "O";
		subject.CityName = "ig";
		subject.PostalCode = "lft";
		subject.Date = "E8NInC";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lft", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "4";
		subject.AddressInformation = "O";
		subject.CityName = "ig";
		subject.StateOrProvinceCode = "Ek";
		subject.Date = "E8NInC";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E8NInC", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "4";
		subject.AddressInformation = "O";
		subject.CityName = "ig";
		subject.StateOrProvinceCode = "Ek";
		subject.PostalCode = "lft";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
