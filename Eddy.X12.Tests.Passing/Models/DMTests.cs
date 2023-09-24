using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DM*b*uR*a*vfj0*2*M*7*2*5*X*V*L*1*6*6*1*4*2*3*4*8";

		var expected = new DM_DemurrageDetentionStorageRate()
		{
			GeographyQualifierCode = "b",
			RateValueQualifier = "uR",
			TimeQualifier = "a",
			Time = "vfj0",
			NumberOfPeriods = 2,
			TimePeriodQualifier = "M",
			NumberOfPeriods2 = 7,
			Rate = 2,
			IntermodalServiceCode = "5",
			TariffApplicationCode = "X",
			BillingCode = "V",
			TimePeriodQualifier2 = "L",
			NumberOfPeriods3 = 1,
			NumberOfPeriods4 = 6,
			Rate2 = 6,
			NumberOfPeriods5 = 1,
			Rate3 = 4,
			NumberOfPeriods6 = 2,
			Rate4 = 3,
			NumberOfPeriods7 = 4,
			Rate5 = 8,
		};

		var actual = Map.MapObject<DM_DemurrageDetentionStorageRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.RateValueQualifier = "uR";
		subject.NumberOfPeriods = 2;
		subject.TimePeriodQualifier = "M";
		subject.NumberOfPeriods2 = 7;
		subject.Rate = 2;
		subject.GeographyQualifierCode = geographyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uR", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "b";
		subject.NumberOfPeriods = 2;
		subject.TimePeriodQualifier = "M";
		subject.NumberOfPeriods2 = 7;
		subject.Rate = 2;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("a", "vfj0", true)]
	[InlineData("", "vfj0", false)]
	[InlineData("a", "", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "b";
		subject.RateValueQualifier = "uR";
		subject.NumberOfPeriods = 2;
		subject.TimePeriodQualifier = "M";
		subject.NumberOfPeriods2 = 7;
		subject.Rate = 2;
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "b";
		subject.RateValueQualifier = "uR";
		subject.TimePeriodQualifier = "M";
		subject.NumberOfPeriods2 = 7;
		subject.Rate = 2;
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "b";
		subject.RateValueQualifier = "uR";
		subject.NumberOfPeriods = 2;
		subject.NumberOfPeriods2 = 7;
		subject.Rate = 2;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumberOfPeriods2(int numberOfPeriods2, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "b";
		subject.RateValueQualifier = "uR";
		subject.NumberOfPeriods = 2;
		subject.TimePeriodQualifier = "M";
		subject.Rate = 2;
		if (numberOfPeriods2 > 0)
		subject.NumberOfPeriods2 = numberOfPeriods2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "b";
		subject.RateValueQualifier = "uR";
		subject.NumberOfPeriods = 2;
		subject.TimePeriodQualifier = "M";
		subject.NumberOfPeriods2 = 7;
		if (rate > 0)
		subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("5", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("5", "", false)]
	public void Validation_AllAreRequiredIntermodalServiceCode(string intermodalServiceCode, string tariffApplicationCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "b";
		subject.RateValueQualifier = "uR";
		subject.NumberOfPeriods = 2;
		subject.TimePeriodQualifier = "M";
		subject.NumberOfPeriods2 = 7;
		subject.Rate = 2;
		subject.IntermodalServiceCode = intermodalServiceCode;
		subject.TariffApplicationCode = tariffApplicationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
