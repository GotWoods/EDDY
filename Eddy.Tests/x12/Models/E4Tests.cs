using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E4*ti*Vm*EmV*QS*h";

		var expected = new E4_EmptyCarDispositionPendedDestinationCity()
		{
			CityName = "ti",
			StateOrProvinceCode = "Vm",
			PostalCode = "EmV",
			CountryCode = "QS",
			AddressInformation = "h",
		};

		var actual = Map.MapObject<E4_EmptyCarDispositionPendedDestinationCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ti", true)]
	public void Validatation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.StateOrProvinceCode = "Vm";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vm", true)]
	public void Validatation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.CityName = "ti";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
