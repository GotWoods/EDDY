using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class E4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E4*NV*NG*U37*4k";

		var expected = new E4_EmptyCarDispositionPendedDestinationCity()
		{
			CityName = "NV",
			StateOrProvinceCode = "NG",
			PostalCode = "U37",
			CountryCode = "4k",
		};

		var actual = Map.MapObject<E4_EmptyCarDispositionPendedDestinationCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NV", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.StateOrProvinceCode = "NG";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NG", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.CityName = "NV";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
