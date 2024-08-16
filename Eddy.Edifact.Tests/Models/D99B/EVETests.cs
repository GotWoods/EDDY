using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class EVETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EVE+F++++n";

		var expected = new EVE_Event()
		{
			EventDetailsCodeQualifier = "F",
			EventCategory = null,
			EventType = null,
			EventIdentification = null,
			ActionRequestNotificationDescriptionCode = "n",
		};

		var actual = Map.MapObject<EVE_Event>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
