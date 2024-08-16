using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class DMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DMS+++z";

		var expected = new DMS_DocumentMessageSummary()
		{
			DocumentMessageIdentification = null,
			DocumentMessageName = null,
			TotalNumberOfItems = "z",
		};

		var actual = Map.MapObject<DMS_DocumentMessageSummary>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
