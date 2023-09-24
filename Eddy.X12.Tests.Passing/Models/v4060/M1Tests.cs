using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class M1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M1*QU*22*mr*4x*64*L*q3*2*z*6*Q*4";

		var expected = new M1_Insurance()
		{
			CountryCode = "QU",
			CarriageValue = 22,
			DeclaredValue = "mr",
			RateValueQualifier = "4x",
			EntityIdentifierCode = "64",
			FreeFormInformation = "L",
			RateValueQualifier2 = "q3",
			MonetaryAmount = 2,
			PercentQualifier = "z",
			PercentageAsDecimal = 6,
			PercentQualifier2 = "Q",
			PercentageAsDecimal2 = 4,
		};

		var actual = Map.MapObject<M1_Insurance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QU", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = countryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "q3";
			subject.MonetaryAmount = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "z";
			subject.PercentageAsDecimal = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.PercentageAsDecimal2 > 0)
		{
			subject.PercentQualifier2 = "Q";
			subject.PercentageAsDecimal2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("q3", 2, true)]
	[InlineData("q3", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "QU";
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "z";
			subject.PercentageAsDecimal = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.PercentageAsDecimal2 > 0)
		{
			subject.PercentQualifier2 = "Q";
			subject.PercentageAsDecimal2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("z", 6, true)]
	[InlineData("z", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "QU";
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0)
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "q3";
			subject.MonetaryAmount = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.PercentageAsDecimal2 > 0)
		{
			subject.PercentQualifier2 = "Q";
			subject.PercentageAsDecimal2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Q", 4, true)]
	[InlineData("Q", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredPercentQualifier2(string percentQualifier2, decimal percentageAsDecimal2, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "QU";
		subject.PercentQualifier2 = percentQualifier2;
		if (percentageAsDecimal2 > 0)
			subject.PercentageAsDecimal2 = percentageAsDecimal2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "q3";
			subject.MonetaryAmount = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "z";
			subject.PercentageAsDecimal = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
