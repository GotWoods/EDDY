using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01A;
using Eddy.Edifact.Models.D01A.Composites;

namespace Eddy.Edifact.Tests.Models.D01A;

public class ITMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ITM+";

		var expected = new ITM_ItemNumber()
		{
			ItemNumberIdentification = null,
		};

		var actual = Map.MapObject<ITM_ItemNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
