using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class IMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IMD+E+++j";

		var expected = new IMD_ItemDescription()
		{
			DescriptionFormatCode = "E",
			ItemCharacteristic = null,
			ItemDescription = null,
			SurfaceOrLayerCode = "j",
		};

		var actual = Map.MapObject<IMD_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
