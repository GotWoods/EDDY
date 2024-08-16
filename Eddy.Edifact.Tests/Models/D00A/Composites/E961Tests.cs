using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:n:2:b:U:i:B:o:K:o";

		var expected = new E961_TransportDetails()
		{
			TransportMeansDescriptionCode = "W",
			JourneyStopsQuantity = "n",
			JourneyLegDurationValue = "2",
			Percentage = "b",
			DaysOfWeekSetIdentifier = "U",
			DateOrTimeOrPeriodValue = "i",
			TransportMeansChangeIndicatorCode = "B",
			LocationNameCode = "o",
			LocationNameCode2 = "K",
			LocationNameCode3 = "o",
		};

		var actual = Map.MapComposite<E961_TransportDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
