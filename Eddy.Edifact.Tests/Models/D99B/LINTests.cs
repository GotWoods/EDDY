using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LIN+0+u+++N+W";

		var expected = new LIN_LineItem()
		{
			LineItemNumber = "0",
			ActionRequestNotificationDescriptionCode = "u",
			ItemNumberIdentification = null,
			SubLineInformation = null,
			ConfigurationLevel = "N",
			ConfigurationCoded = "W",
		};

		var actual = Map.MapObject<LIN_LineItem>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
