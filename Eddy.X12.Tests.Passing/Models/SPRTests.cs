using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPR*iF*4*4*7*3*g*4*5*Ft";

		var expected = new SPR_SupplierRating()
		{
			RatingCategoryCode = "iF",
			MeasurementValue = 4,
			RangeMinimum = 4,
			RangeMaximum = 7,
			RatingSummaryValueCode = "3",
			Description = "g",
			MeasurementValue2 = 4,
			InformationStatusCode = "5",
			UnitOfTimePeriodOrIntervalCode = "Ft",
		};

		var actual = Map.MapObject<SPR_SupplierRating>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "iF", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBMeasurementValue2(decimal measurementValue2, string ratingCategoryCode, bool isValidExpected)
	{
		var subject = new SPR_SupplierRating();
		if (measurementValue2 > 0)
		subject.MeasurementValue2 = measurementValue2;
		subject.RatingCategoryCode = ratingCategoryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "iF", true)]
	[InlineData("Ft", "", false)]
	public void Validation_ARequiresBUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, string ratingCategoryCode, bool isValidExpected)
	{
		var subject = new SPR_SupplierRating();
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		subject.RatingCategoryCode = ratingCategoryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
