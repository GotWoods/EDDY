using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class M1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M1*yK*81*lU*t5*N2*V*Vd*3*i*8*y*8";

		var expected = new M1_Insurance()
		{
			CountryCode = "yK",
			CarriageValue = 81,
			DeclaredValue = "lU",
			RateValueQualifier = "t5",
			EntityIdentifierCode = "N2",
			FreeFormMessage = "V",
			RateValueQualifier2 = "Vd",
			MonetaryAmount = 3,
			PercentQualifier = "i",
			Percent = 8,
			PercentQualifier2 = "y",
			Percent2 = 8,
		};

		var actual = Map.MapObject<M1_Insurance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yK", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = countryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "Vd";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "i";
			subject.Percent = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "y";
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Vd", 3, true)]
	[InlineData("Vd", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "yK";
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "i";
			subject.Percent = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "y";
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("i", 8, true)]
	[InlineData("i", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "yK";
		subject.PercentQualifier = percentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "Vd";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier2) || !string.IsNullOrEmpty(subject.PercentQualifier2) || subject.Percent2 > 0)
		{
			subject.PercentQualifier2 = "y";
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("y", 8, true)]
	[InlineData("y", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPercentQualifier2(string percentQualifier2, decimal percent2, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "yK";
		subject.PercentQualifier2 = percentQualifier2;
		if (percent2 > 0)
			subject.Percent2 = percent2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier2 = "Vd";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "i";
			subject.Percent = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
