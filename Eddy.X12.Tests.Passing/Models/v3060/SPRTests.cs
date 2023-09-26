using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPR*Ty*9*5*8*m*f*1";

		var expected = new SPR_SupplierRating()
		{
			RatingCategoryCode = "Ty",
			MeasurementValue = 9,
			RangeMinimum = 5,
			RangeMaximum = 8,
			RatingSummaryValueCode = "m",
			Description = "f",
			MeasurementValue2 = 1,
		};

		var actual = Map.MapObject<SPR_SupplierRating>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Ty", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Ty", true)]
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
