using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E993Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:0:a:r:m:u:R";

		var expected = new E993_TourDetails()
		{
			ProductIdentifier = "t",
			PartyName = "0",
			LengthDimensionValue = "a",
			JourneyStopsQuantity = "r",
			DaysOfWeekSetIdentifier = "m",
			UnitsQuantity = "u",
			Quantity = "R",
		};

		var actual = Map.MapComposite<E993_TourDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
