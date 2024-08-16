using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DMS+++p";

		var expected = new DMS_DocumentMessageSummary()
		{
			DocumentMessageIdentification = null,
			DocumentMessageName = null,
			ItemTotalQuantity = "p",
		};

		var actual = Map.MapObject<DMS_DocumentMessageSummary>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
