using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*k*ve*9Y*Bc*y*5y*ai*pmv4wK*oDq*aKXi4B*CiB*e8";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "k",
			CityName = "ve",
			StateOrProvinceCode = "9Y",
			CountryCode = "Bc",
			FreightStationAccountingCode2 = "y",
			CityName2 = "5y",
			StateOrProvinceCode2 = "ai",
			StandardPointLocationCode = "pmv4wK",
			PostalCode = "oDq",
			StandardPointLocationCode2 = "aKXi4B",
			PostalCode2 = "CiB",
			CountryCode2 = "e8",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ve", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "9Y";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Y", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.CityName = "ve";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
