using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class U4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "U4*FZ*tK*4Tnp*Hd*IPrD2k";

		var expected = new U4_UltimateConsigneeCity()
		{
			CityName = "FZ",
			StateOrProvinceCode = "tK",
			PostalCode = "4Tnp",
			CountryCode = "Hd",
			StandardPointLocationCode = "IPrD2k",
		};

		var actual = Map.MapObject<U4_UltimateConsigneeCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FZ", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new U4_UltimateConsigneeCity();
		subject.StateOrProvinceCode = "tK";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tK", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new U4_UltimateConsigneeCity();
		subject.CityName = "FZ";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
