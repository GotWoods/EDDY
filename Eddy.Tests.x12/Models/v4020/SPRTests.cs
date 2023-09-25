using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class SPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPR*43*1*2*8*d*2*2*J*C9";

		var expected = new SPR_SupplierRating()
		{
			RatingCategoryCode = "43",
			MeasurementValue = 1,
			RangeMinimum = 2,
			RangeMaximum = 8,
			RatingSummaryValueCode = "d",
			Description = "2",
			MeasurementValue2 = 2,
			InformationStatusCode = "J",
			UnitOfTimePeriodOrInterval = "C9",
		};

		var actual = Map.MapObject<SPR_SupplierRating>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "43", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "43", true)]
	public void Validation_ARequiresBMeasurementValue2(decimal measurementValue2, string ratingCategoryCode, bool isValidExpected)
	{
		var subject = new SPR_SupplierRating();
		//Required fields
		//Test Parameters
		if (measurementValue2 > 0) 
			subject.MeasurementValue2 = measurementValue2;
		subject.RatingCategoryCode = ratingCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C9", "43", true)]
	[InlineData("C9", "", false)]
	[InlineData("", "43", true)]
	public void Validation_ARequiresBUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string ratingCategoryCode, bool isValidExpected)
	{
		var subject = new SPR_SupplierRating();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.RatingCategoryCode = ratingCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
