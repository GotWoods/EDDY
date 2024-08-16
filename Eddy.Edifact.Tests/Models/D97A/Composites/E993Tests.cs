using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E993Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "c:v:z:3:i:Y:y";

		var expected = new E993_TourDetails()
		{
			ProductIdentification = "c",
			PartyName = "v",
			LengthDimension = "z",
			NumberOfStops = "3",
			DaysOfOperation = "i",
			NumberOfUnits = "Y",
			Quantity = "y",
		};

		var actual = Map.MapComposite<E993_TourDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
