using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class E4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E4*FY*sk*3bc*ka";

		var expected = new E4_EmptyCarDispositionPendedDestinationCity()
		{
			CityName = "FY",
			StateOrProvinceCode = "sk",
			PostalCode = "3bc",
			CountryCode = "ka",
		};

		var actual = Map.MapObject<E4_EmptyCarDispositionPendedDestinationCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FY", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.StateOrProvinceCode = "sk";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sk", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.CityName = "FY";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
