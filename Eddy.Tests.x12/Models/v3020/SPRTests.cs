using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPR*aN*5*4*2*l*y";

		var expected = new SPR_SupplierRating()
		{
			RatingCategoryCode = "aN",
			MeasurementValue = 5,
			RangeMinimum = 4,
			RangeMaximum = 2,
			RatingSummaryValueCode = "l",
			Description = "y",
		};

		var actual = Map.MapObject<SPR_SupplierRating>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
