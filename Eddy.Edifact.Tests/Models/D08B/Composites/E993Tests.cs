using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E993Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:h:Z:w:7:B:0";

		var expected = new E993_TourDetails()
		{
			ProductIdentifier = "5",
			PartyName = "h",
			LengthMeasure = "Z",
			JourneyStopsQuantity = "w",
			DaysOfWeekSetIdentifier = "7",
			UnitsQuantity = "B",
			Quantity = "0",
		};

		var actual = Map.MapComposite<E993_TourDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
