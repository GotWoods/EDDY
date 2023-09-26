using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHT*2*MWJVodFlCF1MM4*BFFq";

		var expected = new LHT_TransborderHazardousRequirements()
		{
			HazardousClassificationCode = "2",
			HazardousPlacardNotationCode = "MWJVodFlCF1MM4",
			HazardousEndorsementCode = "BFFq",
		};

		var actual = Map.MapObject<LHT_TransborderHazardousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
