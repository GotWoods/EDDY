using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class CNYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CNY+w++x+I+X";

		var expected = new CNY_CountryInformation()
		{
			CountryNameCode = "w",
			DateAndTimeInformation = null,
			TimeVariationQuantity = "x",
			CurrencyIdentificationCode = "I",
			LanguageNameCode = "X",
		};

		var actual = Map.MapObject<CNY_CountryInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredCountryNameCode(string countryNameCode, bool isValidExpected)
	{
		var subject = new CNY_CountryInformation();
		//Required fields
		//Test Parameters
		subject.CountryNameCode = countryNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
