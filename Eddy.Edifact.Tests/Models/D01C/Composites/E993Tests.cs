using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E993Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Y:s:A:i:H:t:v";

		var expected = new E993_TourDetails()
		{
			ProductIdentifier = "Y",
			PartyName = "s",
			LengthMeasure = "A",
			JourneyStopsQuantity = "i",
			DaysOfWeekSetIdentifier = "H",
			UnitsQuantity = "t",
			Quantity = "v",
		};

		var actual = Map.MapComposite<E993_TourDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
