using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class E961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "r:R:r:N:a:5:c:7:m:d";

		var expected = new E961_TransportDetails()
		{
			TransportMeansDescriptionCode = "r",
			JourneyStopsQuantity = "R",
			JourneyLegDurationQuantity = "r",
			Percentage = "N",
			DaysOfWeekSetIdentifier = "a",
			DateOrTimeOrPeriodText = "5",
			TransportMeansChangeIndicatorCode = "c",
			LocationNameCode = "7",
			LocationNameCode2 = "m",
			LocationNameCode3 = "d",
		};

		var actual = Map.MapComposite<E961_TransportDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
