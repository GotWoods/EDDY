using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PIT+c+H++O+S+t+q";

		var expected = new PIT_PriceItemLine()
		{
			LineItemNumber = "c",
			ActionRequestNotificationCoded = "H",
			PriceChangeInformation = null,
			ArticleAvailabilityCoded = "O",
			SubLineIndicatorCoded = "S",
			ConfigurationLevel = "t",
			ConfigurationCoded = "q",
		};

		var actual = Map.MapObject<PIT_PriceItemLine>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
