using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E973Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "d:e:E";

		var expected = new E973_DeliveringSystemDetails()
		{
			PartyName = "d",
			LocationIdentifier = "e",
			LocationName = "E",
		};

		var actual = Map.MapComposite<E973_DeliveringSystemDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
