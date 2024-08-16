using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:R:R:v:T:V:Q:m:u:F";

		var expected = new E961_TransportDetails()
		{
			TransportMeansDescriptionCode = "x",
			JourneyStopsQuantity = "R",
			JourneyLegDurationQuantity = "R",
			Percentage = "v",
			DaysOfWeekSetIdentifier = "T",
			DateOrTimeOrPeriodValue = "V",
			TransportMeansChangeIndicatorCode = "Q",
			LocationNameCode = "m",
			LocationNameCode2 = "u",
			LocationNameCode3 = "F",
		};

		var actual = Map.MapComposite<E961_TransportDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
