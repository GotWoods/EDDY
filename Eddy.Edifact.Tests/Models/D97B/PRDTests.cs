using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class PRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRD++G";

		var expected = new PRD_ProductIdentification()
		{
			ProductIdentificationDetails = null,
			PartyName = "G",
		};

		var actual = Map.MapObject<PRD_ProductIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
