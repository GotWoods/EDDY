using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DM*l*Q2*l*nM85*3*d*5*2*K*0*e*3*1*5*8*1*6*3*5*9*6";

		var expected = new DM_DemurrageDetentionStorageRate()
		{
			GeographyQualifierCode = "l",
			RateValueQualifier = "Q2",
			TimeQualifier = "l",
			Time = "nM85",
			NumberOfPeriods = 3,
			TimePeriodQualifier = "d",
			NumberOfPeriods2 = 5,
			Rate = 2,
			TOFCIntermodalCodeQualifier = "K",
			TariffApplicationCode = "0",
			BillingCode = "e",
			TimePeriodQualifier2 = "3",
			NumberOfPeriods3 = 1,
			NumberOfPeriods4 = 5,
			Rate2 = 8,
			NumberOfPeriods5 = 1,
			Rate3 = 6,
			NumberOfPeriods6 = 3,
			Rate4 = 5,
			NumberOfPeriods7 = 9,
			Rate5 = 6,
		};

		var actual = Map.MapObject<DM_DemurrageDetentionStorageRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.RateValueQualifier = "Q2";
		subject.TimeQualifier = "l";
		subject.NumberOfPeriods = 3;
		subject.TimePeriodQualifier = "d";
		subject.NumberOfPeriods2 = 5;
		subject.Rate = 2;
		subject.GeographyQualifierCode = geographyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q2", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "l";
		subject.TimeQualifier = "l";
		subject.NumberOfPeriods = 3;
		subject.TimePeriodQualifier = "d";
		subject.NumberOfPeriods2 = 5;
		subject.Rate = 2;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTimeQualifier(string timeQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "l";
		subject.RateValueQualifier = "Q2";
		subject.NumberOfPeriods = 3;
		subject.TimePeriodQualifier = "d";
		subject.NumberOfPeriods2 = 5;
		subject.Rate = 2;
		subject.TimeQualifier = timeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "l";
		subject.RateValueQualifier = "Q2";
		subject.TimeQualifier = "l";
		subject.TimePeriodQualifier = "d";
		subject.NumberOfPeriods2 = 5;
		subject.Rate = 2;
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "l";
		subject.RateValueQualifier = "Q2";
		subject.TimeQualifier = "l";
		subject.NumberOfPeriods = 3;
		subject.NumberOfPeriods2 = 5;
		subject.Rate = 2;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumberOfPeriods2(int numberOfPeriods2, bool isValidExpected)
	{
		var subject = new DM_DemurrageDetentionStorageRate();
		subject.GeographyQualifierCode = "l";
		subject.RateValueQualifier = "Q2";
		subject.TimeQualifier = "l";
		subject.NumberOfPeriods = 3;
		subject.TimePeriodQualifier = "d";
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
		subject.GeographyQualifierCode = "l";
		subject.RateValueQualifier = "Q2";
		subject.TimeQualifier = "l";
		subject.NumberOfPeriods = 3;
		subject.TimePeriodQualifier = "d";
		subject.NumberOfPeriods2 = 5;
		if (rate > 0)
		subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
