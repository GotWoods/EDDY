using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DM*U*h6*P*Scoq*7*c*3*7*U*7*J*I*8*4*4*4*5*4*6*8*2";

		var expected = new DM_DemurrageDetentionStorageRate()
		{
			GeographyQualifierCode = "U",
			RateValueQualifier = "h6",
			TimeQualifier = "P",
			Time = "Scoq",
			NumberOfPeriods = 7,
			TimePeriodQualifier = "c",
			NumberOfPeriods2 = 3,
			Rate = 7,
			TOFCIntermodalCodeQualifier = "U",
			TariffApplicationCode = "7",
			BillingCode = "J",
			TimePeriodQualifier2 = "I",
			NumberOfPeriods3 = 8,
			NumberOfPeriods4 = 4,
			Rate2 = 4,
			NumberOfPeriods5 = 4,
			Rate3 = 5,
			NumberOfPeriods6 = 4,
			Rate4 = 6,
			NumberOfPeriods7 = 8,
			Rate5 = 2,
		};

		var actual = Map.MapObject<DM_DemurrageDetentionStorageRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.RateValueQualifier = "h6";
		subject.TimeQualifier = "P";
		subject.NumberOfPeriods = 7;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 3;
		subject.Rate = 7;
		subject.GeographyQualifierCode = geographyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h6", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "U";
		subject.TimeQualifier = "P";
		subject.NumberOfPeriods = 7;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 3;
		subject.Rate = 7;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTimeQualifier(string timeQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "U";
		subject.RateValueQualifier = "h6";
		subject.NumberOfPeriods = 7;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 3;
		subject.Rate = 7;
		subject.TimeQualifier = timeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "U";
		subject.RateValueQualifier = "h6";
		subject.TimeQualifier = "P";
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 3;
		subject.Rate = 7;
		if (numberOfPeriods > 0)
			subject.NumberOfPeriods = numberOfPeriods;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "U";
		subject.RateValueQualifier = "h6";
		subject.TimeQualifier = "P";
		subject.NumberOfPeriods = 7;
		subject.NumberOfPeriods2 = 3;
		subject.Rate = 7;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumberOfPeriods2(int numberOfPeriods2, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "U";
		subject.RateValueQualifier = "h6";
		subject.TimeQualifier = "P";
		subject.NumberOfPeriods = 7;
		subject.TimePeriodQualifier = "c";
		subject.Rate = 7;
		if (numberOfPeriods2 > 0)
			subject.NumberOfPeriods2 = numberOfPeriods2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "U";
		subject.RateValueQualifier = "h6";
		subject.TimeQualifier = "P";
		subject.NumberOfPeriods = 7;
		subject.TimePeriodQualifier = "c";
		subject.NumberOfPeriods2 = 3;
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
