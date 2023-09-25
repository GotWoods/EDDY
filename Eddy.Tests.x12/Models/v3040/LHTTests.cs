using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHT*w*qfMBjVAR9PUV28*vR4B";

		var expected = new LHT_TransborderHazardousRequirements()
		{
			HazardousClassification = "w",
			HazardousPlacardNotation = "qfMBjVAR9PUV28",
			HazardousEndorsement = "vR4B",
		};

		var actual = Map.MapObject<LHT_TransborderHazardousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
