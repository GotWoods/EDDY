using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class INDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IND++";

		var expected = new IND_IndexDetails()
		{
			IndexIdentification = null,
			IndexValue = null,
		};

		var actual = Map.MapObject<IND_IndexDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
