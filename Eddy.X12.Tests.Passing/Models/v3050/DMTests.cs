using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DM*F*oX*V*zmym*1*W*9*1*H*S*7*t*3*3*3*9*7*2*8*7*7";

		var expected = new DM_DemurrageDetentionStorageRate()
		{
			GeographyQualifierCode = "F",
			RateValueQualifier = "oX",
			TimeQualifier = "V",
			Time = "zmym",
			NumberOfPeriods = 1,
			TimePeriodQualifier = "W",
			NumberOfPeriods2 = 9,
			Rate = 1,
			IntermodalServiceCode = "H",
			TariffApplicationCode = "S",
			BillingCode = "7",
			TimePeriodQualifier2 = "t",
			NumberOfPeriods3 = 3,
			NumberOfPeriods4 = 3,
			Rate2 = 3,
			NumberOfPeriods5 = 9,
			Rate3 = 7,
			NumberOfPeriods6 = 2,
			Rate4 = 8,
			NumberOfPeriods7 = 7,
			Rate5 = 7,
		};

		var actual = Map.MapObject<DM_DemurrageDetentionStorageRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.RateValueQualifier = "oX";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "W";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.GeographyQualifierCode = geographyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "zmym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "H";
			subject.TariffApplicationCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oX", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "F";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "W";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "zmym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "H";
			subject.TariffApplicationCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "zmym", true)]
	[InlineData("V", "", false)]
	[InlineData("", "zmym", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "F";
		subject.RateValueQualifier = "oX";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "W";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "H";
			subject.TariffApplicationCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "F";
		subject.RateValueQualifier = "oX";
		subject.TimePeriodQualifier = "W";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		if (numberOfPeriods > 0)
			subject.NumberOfPeriods = numberOfPeriods;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "zmym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "H";
			subject.TariffApplicationCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "F";
		subject.RateValueQualifier = "oX";
		subject.NumberOfPeriods = 1;
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.TimePeriodQualifier = timePeriodQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "zmym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "H";
			subject.TariffApplicationCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfPeriods2(int numberOfPeriods2, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "F";
		subject.RateValueQualifier = "oX";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "W";
		subject.Rate = 1;
		if (numberOfPeriods2 > 0)
			subject.NumberOfPeriods2 = numberOfPeriods2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "zmym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "H";
			subject.TariffApplicationCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "F";
		subject.RateValueQualifier = "oX";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "W";
		subject.NumberOfPeriods2 = 9;
		if (rate > 0)
			subject.Rate = rate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "zmym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "H";
			subject.TariffApplicationCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "S", true)]
	[InlineData("H", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredIntermodalServiceCode(string intermodalServiceCode, string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "F";
		subject.RateValueQualifier = "oX";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "W";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.IntermodalServiceCode = intermodalServiceCode;
		subject.TariffApplicationCode = tariffApplicationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "zmym";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
