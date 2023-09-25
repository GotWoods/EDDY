using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMA*h*3*zB*nz*lslV*J";

		var expected = new SMA_StationAddress()
		{
			AddressTypeCode = "h",
			AddressInformation = "3",
			CityName = "zB",
			StateOrProvinceCode = "nz",
			PostalCode = "lslV",
			CompensationQualifier = "J",
		};

		var actual = Map.MapObject<SMA_StationAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredAddressTypeCode(string addressTypeCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressInformation = "3";
		subject.CityName = "zB";
		subject.StateOrProvinceCode = "nz";
		subject.PostalCode = "lslV";
		subject.CompensationQualifier = "J";
		//Test Parameters
		subject.AddressTypeCode = addressTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "h";
		subject.CityName = "zB";
		subject.StateOrProvinceCode = "nz";
		subject.PostalCode = "lslV";
		subject.CompensationQualifier = "J";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zB", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "h";
		subject.AddressInformation = "3";
		subject.StateOrProvinceCode = "nz";
		subject.PostalCode = "lslV";
		subject.CompensationQualifier = "J";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nz", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "h";
		subject.AddressInformation = "3";
		subject.CityName = "zB";
		subject.PostalCode = "lslV";
		subject.CompensationQualifier = "J";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lslV", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "h";
		subject.AddressInformation = "3";
		subject.CityName = "zB";
		subject.StateOrProvinceCode = "nz";
		subject.CompensationQualifier = "J";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredCompensationQualifier(string compensationQualifier, bool isValidExpected)
	{
		var subject = new SMA_StationAddress();
		//Required fields
		subject.AddressTypeCode = "h";
		subject.AddressInformation = "3";
		subject.CityName = "zB";
		subject.StateOrProvinceCode = "nz";
		subject.PostalCode = "lslV";
		//Test Parameters
		subject.CompensationQualifier = compensationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
