using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class EVETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EVE+9++++V";

		var expected = new EVE_Event()
		{
			EventDetailsCodeQualifier = "9",
			EventCategory = null,
			EventType = null,
			EventIdentification = null,
			ActionCode = "V",
		};

		var actual = Map.MapObject<EVE_Event>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
