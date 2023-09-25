using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPR*Tz*4*9*4*u*I*9";

		var expected = new SPR_SupplierRating()
		{
			RatingCategoryCode = "Tz",
			MeasurementValue = 4,
			RangeMinimum = 9,
			RangeMaximum = 4,
			RatingSummaryValueCode = "u",
			Description = "I",
			MeasurementValue2 = 9,
		};

		var actual = Map.MapObject<SPR_SupplierRating>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "Tz", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "Tz", true)]
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

}
