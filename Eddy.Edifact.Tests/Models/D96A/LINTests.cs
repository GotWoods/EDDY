using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LIN+k+5+++a+2";

		var expected = new LIN_LineItem()
		{
			LineItemNumber = "k",
			ActionRequestNotificationCoded = "5",
			ItemNumberIdentification = null,
			SubLineInformation = null,
			ConfigurationLevel = "a",
			ConfigurationCoded = "2",
		};

		var actual = Map.MapObject<LIN_LineItem>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
