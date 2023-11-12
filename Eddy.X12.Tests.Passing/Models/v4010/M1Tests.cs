using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class M1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M1*8J*78*Mc*rl*hV*N*17*1*D*2*e*7";

		var expected = new M1_Insurance()
		{
			CountryCode = "8J",
			CarriageValue = 78,
			DeclaredValue = "Mc",
			RateValueQualifier = "rl",
			EntityIdentifierCode = "hV",
			FreeFormMessage = "N",
			RateValueQualifier2 = "17",
			MonetaryAmount = 1,
			PercentQualifier = "D",
			Percent = 2,
			PercentQualifier2 = "e",
			Percent2 = 7,
		};

		var actual = Map.MapObject<M1_Insurance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8J", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = countryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "17";
			subject.MonetaryAmount = 1;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "D";
			subject.Percent = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "e";
			subject.Percent2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("17", 1, true)]
	[InlineData("17", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "8J";
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "D";
			subject.Percent = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "e";
			subject.Percent2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 2, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "8J";
		subject.PercentQualifier = percentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "17";
			subject.MonetaryAmount = 1;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "e";
			subject.Percent2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e", 7, true)]
	[InlineData("e", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredPercentQualifier2(string percentQualifier2, decimal percent2, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "8J";
		subject.PercentQualifier2 = percentQualifier2;
		if (percent2 > 0)
			subject.Percent2 = percent2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "17";
			subject.MonetaryAmount = 1;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "D";
			subject.Percent = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
