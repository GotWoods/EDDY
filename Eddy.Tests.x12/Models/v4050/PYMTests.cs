using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class PYMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PYM*eC*Mw*1*1*k*hb*2";

		var expected = new PYM_PaymentMannerAndPercentage()
		{
			RatingCode = "eC",
			UnitOfTimePeriodOrInterval = "Mw",
			NumberOfPeriods = 1,
			NumberOfPeriods2 = 1,
			TimePeriodQualifier = "k",
			RatingRemarksCode = "hb",
			PercentageAsDecimal = 2,
		};

		var actual = Map.MapObject<PYM_PaymentMannerAndPercentage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("eC", "hb", true)]
	[InlineData("eC", "", true)]
	[InlineData("", "hb", true)]
	public void Validation_AtLeastOneRatingCode(string ratingCode, string ratingRemarksCode, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		subject.RatingCode = ratingCode;
		subject.RatingRemarksCode = ratingRemarksCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrInterval = "Mw";
			subject.NumberOfPeriods = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Mw", 1, true)]
	[InlineData("Mw", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, int numberOfPeriods, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		//A Requires B
		if (numberOfPeriods > 0)
			subject.RatingCode = "eC";
		//At Least one
		subject.RatingCode = "eC";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "eC", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "eC", true)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string ratingCode, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		subject.RatingCode = ratingCode;
		//At Least one
		subject.RatingRemarksCode = "hb";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrInterval = "Mw";
			subject.NumberOfPeriods = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 1, true)]
	[InlineData(1, 0, false)]
	[InlineData(0, 1, true)]
	public void Validation_ARequiresBNumberOfPeriods2(int numberOfPeriods2, int numberOfPeriods, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		if (numberOfPeriods2 > 0) 
			subject.NumberOfPeriods2 = numberOfPeriods2;
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		//A Requires B
		if (numberOfPeriods > 0)
			subject.RatingCode = "eC";
		//At Least one
		subject.RatingCode = "eC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrInterval = "Mw";
			subject.NumberOfPeriods = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("k", 1, true)]
	[InlineData("k", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBTimePeriodQualifier(string timePeriodQualifier, int numberOfPeriods, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		subject.TimePeriodQualifier = timePeriodQualifier;
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		//A Requires B
		if (numberOfPeriods > 0)
			subject.RatingCode = "eC";
		//At Least one
		subject.RatingCode = "eC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrInterval = "Mw";
			subject.NumberOfPeriods = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
