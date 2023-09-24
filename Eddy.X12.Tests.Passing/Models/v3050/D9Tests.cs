using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*M*Dr*iG*r0*8*9v*FT*RRK8ZY*7uh";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "M",
			CityName = "Dr",
			StateOrProvinceCode = "iG",
			CountryCode = "r0",
			FreightStationAccountingCode2 = "8",
			CityName2 = "9v",
			StateOrProvinceCode2 = "FT",
			StandardPointLocationCode = "RRK8ZY",
			PostalCode = "7uh",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dr", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "iG";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iG", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.CityName = "Dr";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
