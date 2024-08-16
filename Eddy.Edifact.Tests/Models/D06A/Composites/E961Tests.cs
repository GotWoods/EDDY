using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:5:I:K:s:t:S:O:E:z";

		var expected = new E961_TransportDetails()
		{
			TransportMeansDescriptionCode = "s",
			JourneyStopsQuantity = "5",
			JourneyLegDurationQuantity = "I",
			Percentage = "K",
			DaysOfWeekSetIdentifier = "s",
			DateOrTimeOrPeriodText = "t",
			TransportMeansChangeIndicatorCode = "S",
			LocationIdentifier = "O",
			LocationIdentifier2 = "E",
			LocationIdentifier3 = "z",
		};

		var actual = Map.MapComposite<E961_TransportDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
