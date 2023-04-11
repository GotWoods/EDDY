using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M1*jn*23*te*6l*zE*X*oY*1*A*7*6*8";

		var expected = new M1_Insurance()
		{
			CountryCode = "jn",
			CarriageValue = 23,
			DeclaredValue = "te",
			RateValueQualifier = "6l",
			EntityIdentifierCode = "zE",
			FreeFormInformation = "X",
			RateValueQualifier2 = "oY",
			MonetaryAmount = 1,
			PercentQualifier = "A",
			PercentageAsDecimal = 7,
			PercentQualifier2 = "6",
			PercentageAsDecimal2 = 8,
		};

		var actual = Map.MapObject<M1_Insurance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jn", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("oY", 1, true)]
	[InlineData("", 1, false)]
	[InlineData("oY", 0, false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "jn";
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("A", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("A", 0, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "jn";
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("6", 8, true)]
	[InlineData("", 8, false)]
	[InlineData("6", 0, false)]
	public void Validation_AllAreRequiredPercentQualifier2(string percentQualifier2, decimal percentageAsDecimal2, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "jn";
		subject.PercentQualifier2 = percentQualifier2;
		if (percentageAsDecimal2 > 0)
		subject.PercentageAsDecimal2 = percentageAsDecimal2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
