using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class N4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N4*xw*4o*huV*Dd*3*0*7";

		var expected = new N4_GeographicLocation()
		{
			CityName = "xw",
			StateOrProvinceCode = "4o",
			PostalCode = "huV",
			CountryCode = "Dd",
			LocationQualifier = "3",
			LocationIdentifier = "0",
			CountrySubdivisionCode = "7",
		};

		var actual = Map.MapObject<N4_GeographicLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4o", "7", false)]
	[InlineData("4o", "", true)]
	[InlineData("", "7", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		if (countrySubdivisionCode != "")
			subject.CountryCode = "Dd";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "3", true)]
	[InlineData("0", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "Dd", true)]
	[InlineData("7", "", false)]
	[InlineData("", "Dd", true)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
