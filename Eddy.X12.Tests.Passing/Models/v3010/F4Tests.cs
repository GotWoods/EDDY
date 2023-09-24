using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F4*WZ*MJ*c6QB*S6*F9T3xS";

		var expected = new F4_ConsignorCity()
		{
			CityName = "WZ",
			StateOrProvinceCode = "MJ",
			PostalCode = "c6QB",
			CountryCode = "S6",
			StandardPointLocationCode = "F9T3xS",
		};

		var actual = Map.MapObject<F4_ConsignorCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WZ", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new F4_ConsignorCity();
		subject.StateOrProvinceCode = "MJ";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MJ", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F4_ConsignorCity();
		subject.CityName = "WZ";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
