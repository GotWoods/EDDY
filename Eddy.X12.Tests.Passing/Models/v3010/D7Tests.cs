using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D7*c6*1i*hc25*hg";

		var expected = new D7_ConsigneesThirdPartyCity()
		{
			CityName = "c6",
			StateOrProvinceCode = "1i",
			PostalCode = "hc25",
			CountryCode = "hg",
		};

		var actual = Map.MapObject<D7_ConsigneesThirdPartyCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c6", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new D7_ConsigneesThirdPartyCity();
		subject.StateOrProvinceCode = "1i";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1i", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D7_ConsigneesThirdPartyCity();
		subject.CityName = "c6";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
