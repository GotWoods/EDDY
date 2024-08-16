using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LIN+Q+n+++o+a";

		var expected = new LIN_LineItem()
		{
			LineItemIdentifier = "Q",
			ActionRequestNotificationDescriptionCode = "n",
			ItemNumberIdentification = null,
			SubLineInformation = null,
			ConfigurationLevelNumber = "o",
			ConfigurationOperationCode = "a",
		};

		var actual = Map.MapObject<LIN_LineItem>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
