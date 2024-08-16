using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class CNYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CNY+V++C+D+d";

		var expected = new CNY_CountryInformation()
		{
			CountryIdentifier = "V",
			DateAndTimeInformation = null,
			TimeVariationQuantity = "C",
			CurrencyIdentificationCode = "D",
			LanguageNameCode = "d",
		};

		var actual = Map.MapObject<CNY_CountryInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredCountryIdentifier(string countryIdentifier, bool isValidExpected)
	{
		var subject = new CNY_CountryInformation();
		//Required fields
		//Test Parameters
		subject.CountryIdentifier = countryIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
