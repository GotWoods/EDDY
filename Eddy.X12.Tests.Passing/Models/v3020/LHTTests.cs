using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHT*aV*3lEC5j91L0RpJy*wzro";

		var expected = new LHT_TransborderHazardousRequirements()
		{
			HazardousClassification = "aV",
			HazardousPlacardNotation = "3lEC5j91L0RpJy",
			HazardousEndorsement = "wzro",
		};

		var actual = Map.MapObject<LHT_TransborderHazardousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
