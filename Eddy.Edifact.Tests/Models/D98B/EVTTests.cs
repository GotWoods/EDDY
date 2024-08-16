using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class EVTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EVT++";

		var expected = new EVT_Event()
		{
			EventType = null,
			EventIdentification = null,
		};

		var actual = Map.MapObject<EVT_Event>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
