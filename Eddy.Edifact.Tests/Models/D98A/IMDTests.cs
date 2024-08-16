using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A;

public class IMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IMD+c+++6";

		var expected = new IMD_ItemDescription()
		{
			ItemDescriptionTypeCoded = "c",
			ItemCharacteristic = null,
			ItemDescription = null,
			SurfaceLayerIndicatorCoded = "6",
		};

		var actual = Map.MapObject<IMD_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
