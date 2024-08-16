using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class PRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRC++";

		var expected = new PRC_ProcessIdentification()
		{
			ProcessTypeAndDescription = null,
			ProcessIdentificationDetails = null,
		};

		var actual = Map.MapObject<PRC_ProcessIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
