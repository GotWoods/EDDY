using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E973Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "z:p:k";

		var expected = new E973_DeliveringSystemDetails()
		{
			PartyName = "z",
			PlaceLocationIdentification = "p",
			PlaceLocation = "k",
		};

		var actual = Map.MapComposite<E973_DeliveringSystemDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
