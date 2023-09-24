using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class M1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M1*VY*38*oK*fF*Tx*a*DW*7*S*5*h*8";

		var expected = new M1_Insurance()
		{
			CountryCode = "VY",
			CarriageValue = 38,
			DeclaredValue = "oK",
			RateValueQualifier = "fF",
			EntityIdentifierCode = "Tx",
			FreeFormMessage = "a",
			RateValueQualifier2 = "DW",
			MonetaryAmount = 7,
			PercentQualifier = "S",
			Percent = 5,
			PercentQualifier2 = "h",
			Percent2 = 8,
		};

		var actual = Map.MapObject<M1_Insurance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VY", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = countryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "DW";
			subject.MonetaryAmount = 7;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "S";
			subject.Percent = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "h";
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("DW", 7, true)]
	[InlineData("DW", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "VY";
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "S";
			subject.Percent = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "h";
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("S", 5, true)]
	[InlineData("S", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "VY";
		subject.PercentQualifier = percentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "DW";
			subject.MonetaryAmount = 7;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "h";
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h", 8, true)]
	[InlineData("h", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPercentQualifier2(string percentQualifier2, decimal percent2, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "VY";
		subject.PercentQualifier2 = percentQualifier2;
		if (percent2 > 0)
			subject.Percent2 = percent2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "DW";
			subject.MonetaryAmount = 7;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "S";
			subject.Percent = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
