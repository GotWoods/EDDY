using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E973Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "N:D:k";

		var expected = new E973_DeliveringSystemDetails()
		{
			PartyName = "N",
			LocationNameCode = "D",
			LocationName = "k",
		};

		var actual = Map.MapComposite<E973_DeliveringSystemDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
