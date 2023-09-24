using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class DMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DM*t*Ig*e*jYkz*8*C*9*1*5*B*W*P*1*7*6*6*1*1*4*5*2";

		var expected = new DM_DemurrageDetentionStorageRate()
		{
			GeographyQualifierCode = "t",
			RateValueQualifier = "Ig",
			TimeQualifier = "e",
			Time = "jYkz",
			NumberOfPeriods = 8,
			TimePeriodQualifier = "C",
			NumberOfPeriods2 = 9,
			Rate = 1,
			IntermodalServiceCode = "5",
			TariffApplicationCode = "B",
			BillingCode = "W",
			TimePeriodQualifier2 = "P",
			NumberOfPeriods3 = 1,
			NumberOfPeriods4 = 7,
			Rate2 = 6,
			NumberOfPeriods5 = 6,
			Rate3 = 1,
			NumberOfPeriods6 = 1,
			Rate4 = 4,
			NumberOfPeriods7 = 5,
			Rate5 = 2,
		};

		var actual = Map.MapObject<DM_DemurrageDetentionStorageRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.RateValueQualifier = "Ig";
		subject.NumberOfPeriods = 8;
		subject.TimePeriodQualifier = "C";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.GeographyQualifierCode = geographyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "5";
			subject.TariffApplicationCode = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ig", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "t";
		subject.NumberOfPeriods = 8;
		subject.TimePeriodQualifier = "C";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "5";
			subject.TariffApplicationCode = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jYkz", "e", true)]
	[InlineData("jYkz", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBTime(string time, string timeQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "t";
		subject.RateValueQualifier = "Ig";
		subject.NumberOfPeriods = 8;
		subject.TimePeriodQualifier = "C";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.Time = time;
		subject.TimeQualifier = timeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "5";
			subject.TariffApplicationCode = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "t";
		subject.RateValueQualifier = "Ig";
		subject.TimePeriodQualifier = "C";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		if (numberOfPeriods > 0)
			subject.NumberOfPeriods = numberOfPeriods;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "5";
			subject.TariffApplicationCode = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "t";
		subject.RateValueQualifier = "Ig";
		subject.NumberOfPeriods = 8;
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.TimePeriodQualifier = timePeriodQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "5";
			subject.TariffApplicationCode = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfPeriods2(int numberOfPeriods2, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "t";
		subject.RateValueQualifier = "Ig";
		subject.NumberOfPeriods = 8;
		subject.TimePeriodQualifier = "C";
		subject.Rate = 1;
		if (numberOfPeriods2 > 0)
			subject.NumberOfPeriods2 = numberOfPeriods2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "5";
			subject.TariffApplicationCode = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "t";
		subject.RateValueQualifier = "Ig";
		subject.NumberOfPeriods = 8;
		subject.TimePeriodQualifier = "C";
		subject.NumberOfPeriods2 = 9;
		if (rate > 0)
			subject.Rate = rate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "5";
			subject.TariffApplicationCode = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "B", true)]
	[InlineData("5", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredIntermodalServiceCode(string intermodalServiceCode, string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "t";
		subject.RateValueQualifier = "Ig";
		subject.NumberOfPeriods = 8;
		subject.TimePeriodQualifier = "C";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 1;
		subject.IntermodalServiceCode = intermodalServiceCode;
		subject.TariffApplicationCode = tariffApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
