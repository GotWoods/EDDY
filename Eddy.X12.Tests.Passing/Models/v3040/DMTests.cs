using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DM*y*UT*T*jELL*1*c*9*7*B*Y*G*x*8*1*3*7*9*1*1*4*5";

		var expected = new DM_DemurrageDetentionStorageRate()
		{
			GeographyQualifierCode = "y",
			RateValueQualifier = "UT",
			TimeQualifier = "T",
			Time = "jELL",
			NumberOfPeriods = 1,
			TimePeriodQualifier = "c",
			NumberOfPeriods2 = 9,
			Rate = 7,
			IntermodalServiceCode = "B",
			TariffApplicationCode = "Y",
			BillingCode = "G",
			TimePeriodQualifier2 = "x",
			NumberOfPeriods3 = 8,
			NumberOfPeriods4 = 1,
			Rate2 = 3,
			NumberOfPeriods5 = 7,
			Rate3 = 9,
			NumberOfPeriods6 = 1,
			Rate4 = 1,
			NumberOfPeriods7 = 4,
			Rate5 = 5,
		};

		var actual = Map.MapObject<DM_DemurrageDetentionStorageRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.RateValueQualifier = "UT";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 7;
		subject.GeographyQualifierCode = geographyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "B";
			subject.TariffApplicationCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UT", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "y";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 7;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "B";
			subject.TariffApplicationCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jELL", "T", true)]
	[InlineData("jELL", "", false)]
	[InlineData("", "T", true)]
	public void Validation_ARequiresBTime(string time, string timeQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "y";
		subject.RateValueQualifier = "UT";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 7;
		subject.Time = time;
		subject.TimeQualifier = timeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "B";
			subject.TariffApplicationCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "y";
		subject.RateValueQualifier = "UT";
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 7;
		if (numberOfPeriods > 0)
			subject.NumberOfPeriods = numberOfPeriods;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "B";
			subject.TariffApplicationCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "y";
		subject.RateValueQualifier = "UT";
		subject.NumberOfPeriods = 1;
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 7;
		subject.TimePeriodQualifier = timePeriodQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "B";
			subject.TariffApplicationCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfPeriods2(int numberOfPeriods2, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "y";
		subject.RateValueQualifier = "UT";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "c";
		subject.Rate = 7;
		if (numberOfPeriods2 > 0)
			subject.NumberOfPeriods2 = numberOfPeriods2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "B";
			subject.TariffApplicationCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "y";
		subject.RateValueQualifier = "UT";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 9;
		if (rate > 0)
			subject.Rate = rate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.IntermodalServiceCode) || !string.IsNullOrEmpty(subject.TariffApplicationCode))
		{
			subject.IntermodalServiceCode = "B";
			subject.TariffApplicationCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "Y", true)]
	[InlineData("B", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredIntermodalServiceCode(string intermodalServiceCode, string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "y";
		subject.RateValueQualifier = "UT";
		subject.NumberOfPeriods = 1;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 9;
		subject.Rate = 7;
		subject.IntermodalServiceCode = intermodalServiceCode;
		subject.TariffApplicationCode = tariffApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
