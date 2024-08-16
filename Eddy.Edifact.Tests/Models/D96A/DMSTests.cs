using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DMS+n+U+z";

		var expected = new DMS_DocumentMessageSummary()
		{
			DocumentMessageNumber = "n",
			DocumentMessageNameCoded = "U",
			TotalNumberOfItems = "z",
		};

		var actual = Map.MapObject<DMS_DocumentMessageSummary>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
