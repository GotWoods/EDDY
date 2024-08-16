using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E973Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "y:5:W";

		var expected = new E973_DeliveringSystemDetails()
		{
			PartyName = "y",
			LocationIdentifier = "5",
			LocationName = "W",
		};

		var actual = Map.MapComposite<E973_DeliveringSystemDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
