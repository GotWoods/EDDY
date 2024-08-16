using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class IMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IMD+k+++W";

		var expected = new IMD_ItemDescription()
		{
			ItemDescriptionTypeCoded = "k",
			ItemCharacteristic = null,
			ItemDescription = null,
			SurfaceLayerCode = "W",
		};

		var actual = Map.MapObject<IMD_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
