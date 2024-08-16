using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class IMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IMD+L+o++2";

		var expected = new IMD_ItemDescription()
		{
			ItemDescriptionTypeCoded = "L",
			ItemCharacteristicCoded = "o",
			ItemDescription = null,
			SurfaceLayerIndicatorCoded = "2",
		};

		var actual = Map.MapObject<IMD_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
