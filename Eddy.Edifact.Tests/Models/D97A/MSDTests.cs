using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class MSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MSD++B";

		var expected = new MSD_MessageActionDetails()
		{
			MessageProcessingDetails = null,
			ResponseTypeCoded = "B",
		};

		var actual = Map.MapObject<MSD_MessageActionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
