using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class E4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E4*AF*lk*ccr*6q*Y";

		var expected = new E4_EmptyCarDispositionPendedDestinationCity()
		{
			CityName = "AF",
			StateOrProvinceCode = "lk",
			PostalCode = "ccr",
			CountryCode = "6q",
			AddressInformation = "Y",
		};

		var actual = Map.MapObject<E4_EmptyCarDispositionPendedDestinationCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AF", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.StateOrProvinceCode = "lk";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lk", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.CityName = "AF";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
