using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*3*si*zB*Sh*I*Yb*uq*heDzS3*ku7";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "3",
			CityName = "si",
			StateOrProvinceCode = "zB",
			CountryCode = "Sh",
			FreightStationAccountingCode2 = "I",
			CityName2 = "Yb",
			StateOrProvinceCode2 = "uq",
			StandardPointLocationCode = "heDzS3",
			PostalCode = "ku7",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("si", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "zB";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zB", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.CityName = "si";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
