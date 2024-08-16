using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E993Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:q:r:A:U:m:I";

		var expected = new E993_TourDetails()
		{
			ProductIdentifier = "M",
			PartyName = "q",
			LengthDimension = "r",
			NumberOfStops = "A",
			DaysOfOperation = "U",
			NumberOfUnits = "m",
			Quantity = "I",
		};

		var actual = Map.MapComposite<E993_TourDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
