using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class WINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "WIN**kA**HL";

		var expected = new WIN_WineInformation()
		{
			CompositeGrapeVarietalSequence = null,
			Color = "kA",
			CompositeDateTimePeriod = null,
			WineQualityDesignation = "HL",
		};

		var actual = Map.MapObject<WIN_WineInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
