using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PYMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PYM*9g*Cb*9*5*v*9m*6";

		var expected = new PYM_PaymentMannerAndPercentage()
		{
			RatingCode = "9g",
			UnitOfTimePeriodOrInterval = "Cb",
			NumberOfPeriods = 9,
			NumberOfPeriods2 = 5,
			TimePeriodQualifier = "v",
			RatingRemarksCode = "9m",
			Percent = 6,
		};

		var actual = Map.MapObject<PYM_PaymentMannerAndPercentage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9g", "9m", true)]
	[InlineData("9g", "", true)]
	[InlineData("", "9m", true)]
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
			subject.UnitOfTimePeriodOrInterval = "Cb";
			subject.NumberOfPeriods = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Cb", 9, true)]
	[InlineData("Cb", 0, false)]
	[InlineData("", 9, false)]
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
			subject.RatingCode = "9g";
		//At Least one
		subject.RatingCode = "9g";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "9g", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "9g", true)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string ratingCode, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		subject.RatingCode = ratingCode;
		//At Least one
		subject.RatingRemarksCode = "9m";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrInterval = "Cb";
			subject.NumberOfPeriods = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 9, true)]
	[InlineData(5, 0, false)]
	[InlineData(0, 9, true)]
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
			subject.RatingCode = "9g";
		//At Least one
		subject.RatingCode = "9g";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrInterval = "Cb";
			subject.NumberOfPeriods = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("v", 9, true)]
	[InlineData("v", 0, false)]
	[InlineData("", 9, true)]
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
			subject.RatingCode = "9g";
		//At Least one
		subject.RatingCode = "9g";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrInterval = "Cb";
			subject.NumberOfPeriods = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
