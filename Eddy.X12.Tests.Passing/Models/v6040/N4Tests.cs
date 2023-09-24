using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.Tests.Models.v6040;

public class N4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N4*84*68*i44*gV*z*1*f*A7u";

		var expected = new N4_GeographicLocation()
		{
			CityName = "84",
			StateOrProvinceCode = "68",
			PostalCode = "i44",
			CountryCode = "gV",
			LocationQualifier = "z",
			LocationIdentifier = "1",
			CountrySubdivisionCode = "f",
			PostalCodeFormatted = "A7u",
		};

		var actual = Map.MapObject<N4_GeographicLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("68", "f", false)]
	[InlineData("68", "", true)]
	[InlineData("", "f", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		if (countrySubdivisionCode != "")
			subject.CountryCode = "gV";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i44", "A7u", false)]
	[InlineData("i44", "", true)]
	[InlineData("", "A7u", true)]
	public void Validation_OnlyOneOfPostalCode(string postalCode, string postalCodeFormatted, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.PostalCode = postalCode;
		subject.PostalCodeFormatted = postalCodeFormatted;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "z", true)]
	[InlineData("1", "", false)]
	[InlineData("", "z", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "gV", true)]
	[InlineData("f", "", false)]
	[InlineData("", "gV", true)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
