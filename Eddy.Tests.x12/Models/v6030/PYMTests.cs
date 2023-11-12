using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class PYMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PYM*CE*Tf*3*1*N*bb*1";

		var expected = new PYM_PaymentMannerAndPercentage()
		{
			RatingCode = "CE",
			UnitOfTimePeriodOrIntervalCode = "Tf",
			NumberOfPeriods = 3,
			NumberOfPeriods2 = 1,
			TimePeriodQualifier = "N",
			RatingRemarksCode = "bb",
			PercentageAsDecimal = 1,
		};

		var actual = Map.MapObject<PYM_PaymentMannerAndPercentage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("CE", "bb", true)]
	[InlineData("CE", "", true)]
	[InlineData("", "bb", true)]
	public void Validation_AtLeastOneRatingCode(string ratingCode, string ratingRemarksCode, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		subject.RatingCode = ratingCode;
		subject.RatingRemarksCode = ratingRemarksCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrIntervalCode = "Tf";
			subject.NumberOfPeriods = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Tf", 3, true)]
	[InlineData("Tf", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, int numberOfPeriods, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		//A Requires B
		if (numberOfPeriods > 0)
			subject.RatingCode = "CE";
		//At Least one
		subject.RatingCode = "CE";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "CE", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "CE", true)]
	public void Validation_ARequiresBNumberOfPeriods(int numberOfPeriods, string ratingCode, bool isValidExpected)
	{
		var subject = new PYM_PaymentMannerAndPercentage();
		//Required fields
		//Test Parameters
		if (numberOfPeriods > 0) 
			subject.NumberOfPeriods = numberOfPeriods;
		subject.RatingCode = ratingCode;
		//At Least one
		subject.RatingRemarksCode = "bb";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrIntervalCode = "Tf";
			subject.NumberOfPeriods = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 3, true)]
	[InlineData(1, 0, false)]
	[InlineData(0, 3, true)]
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
			subject.RatingCode = "CE";
		//At Least one
		subject.RatingCode = "CE";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrIntervalCode = "Tf";
			subject.NumberOfPeriods = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("N", 3, true)]
	[InlineData("N", 0, false)]
	[InlineData("", 3, true)]
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
			subject.RatingCode = "CE";
		//At Least one
		subject.RatingCode = "CE";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || subject.NumberOfPeriods > 0)
		{
			subject.UnitOfTimePeriodOrIntervalCode = "Tf";
			subject.NumberOfPeriods = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
