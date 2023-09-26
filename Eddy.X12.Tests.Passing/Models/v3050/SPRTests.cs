using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPR*pP*4*5*5*i*D";

		var expected = new SPR_SupplierRating()
		{
			RatingCategoryCode = "pP",
			MeasurementValue = 4,
			RangeMinimum = 5,
			RangeMaximum = 5,
			RatingSummaryValueCode = "i",
			Description = "D",
		};

		var actual = Map.MapObject<SPR_SupplierRating>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
