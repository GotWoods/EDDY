using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PYMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PYM*Rd*Eo*1*3*0*Xx*6";

		var expected = new PYM_PaymentMannerAndPercentage()
		{
			RatingCode = "Rd",
			UnitOfTimePeriodOrIntervalCode = "Eo",
			NumberOfPeriods = 1,
			NumberOfPeriods2 = 3,
			TimePeriodQualifier = "0",
			RatingRemarksCode = "Xx",
			PercentageAsDecimal = 6,
		};

		var actual = Map.MapObject<PYM_PaymentMannerAndPercentage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("Rd","Xx", true)]
	[InlineData("", "Xx", true)]
	[InlineData("Rd", "", true)]
	public void Validation_AtLeastOneRatingCode(string ratingCode, string ratingRemarksCode, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		subject.RatingCode = ratingCode;
		subject.RatingRemarksCode = ratingRemarksCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Eo", 1, true)]
	[InlineData("", 1, false)]
	[InlineData("Eo", 0, false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, int numberOfPeriods, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Rd", true)]
	[InlineData(1, "", false)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string ratingCode, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;
		subject.RatingCode = ratingCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 1, true)]
	[InlineData(3, 0, false)]
	public void Validation_ARequiresBNumberOfPeriods2(int numberOfPeriods2, int numberOfPeriods, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		if (numberOfPeriods2 > 0)
		subject.NumberOfPeriods2 = numberOfPeriods2;
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 1, true)]
	[InlineData("0", 0, false)]
	public void Validation_ARequiresBTimePeriodQualifier(string timePeriodQualifier, int numberOfPeriods, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		subject.TimePeriodQualifier = timePeriodQualifier;
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
