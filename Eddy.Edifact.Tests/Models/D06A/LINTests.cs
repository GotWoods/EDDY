using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LIN+a+Q+++I+A";

		var expected = new LIN_LineItem()
		{
			LineItemIdentifier = "a",
			ActionCode = "Q",
			ItemNumberIdentification = null,
			SubLineInformation = null,
			ConfigurationLevelNumber = "I",
			ConfigurationOperationCode = "A",
		};

		var actual = Map.MapObject<LIN_LineItem>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
