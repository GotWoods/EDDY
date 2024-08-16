using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B;

public class PRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRD++n";

		var expected = new PRD_ProductIdentification()
		{
			ProductIdentificationDetails = null,
			PartyName = "n",
		};

		var actual = Map.MapObject<PRD_ProductIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
