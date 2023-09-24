using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class M1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M1*bh*77*ca*mx*qL*F*NW*3*q*1*i*3";

		var expected = new M1_Insurance()
		{
			CountryCode = "bh",
			CarriageValue = 77,
			DeclaredValue = "ca",
			RateValueQualifier = "mx",
			EntityIdentifierCode = "qL",
			FreeFormMessage = "F",
			RateValueQualifier2 = "NW",
			MonetaryAmount = 3,
			PercentQualifier = "q",
			PercentageAsDecimal = 1,
			PercentQualifier2 = "i",
			PercentageAsDecimal2 = 3,
		};

		var actual = Map.MapObject<M1_Insurance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bh", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = countryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "NW";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "q";
			subject.PercentageAsDecimal = 1;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.PercentageAsDecimal2 > 0)
		{
			subject.PercentQualifier2 = "i";
			subject.PercentageAsDecimal2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("NW", 3, true)]
	[InlineData("NW", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "bh";
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "q";
			subject.PercentageAsDecimal = 1;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.PercentageAsDecimal2 > 0)
		{
			subject.PercentQualifier2 = "i";
			subject.PercentageAsDecimal2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("q", 1, true)]
	[InlineData("q", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "bh";
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0)
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "NW";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.PercentageAsDecimal2 > 0)
		{
			subject.PercentQualifier2 = "i";
			subject.PercentageAsDecimal2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("i", 3, true)]
	[InlineData("i", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredPercentQualifier2(string percentQualifier2, decimal percentageAsDecimal2, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "bh";
		subject.PercentQualifier2 = percentQualifier2;
		if (percentageAsDecimal2 > 0)
			subject.PercentageAsDecimal2 = percentageAsDecimal2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "NW";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "q";
			subject.PercentageAsDecimal = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
