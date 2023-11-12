using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class WINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WIN**Dk**fF";

		var expected = new WIN_WineInformation()
		{
			CompositeGrapeVarietalSequence = null,
			Color = "Dk",
			CompositeDateTimePeriod = null,
			WineQualityDesignation = "fF",
		};

		var actual = Map.MapObject<WIN_WineInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
