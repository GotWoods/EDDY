using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class E4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E4*BU*9K*jd1*Td";

		var expected = new E4_EmptyCarDispositionPendedDestinationCity()
		{
			CityName = "BU",
			StateOrProvinceCode = "9K",
			PostalCode = "jd1",
			CountryCode = "Td",
		};

		var actual = Map.MapObject<E4_EmptyCarDispositionPendedDestinationCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BU", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.StateOrProvinceCode = "9K";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9K", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new E4_EmptyCarDispositionPendedDestinationCity();
		subject.CityName = "BU";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
