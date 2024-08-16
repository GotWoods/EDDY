using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class STATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STA+E+";

		var expected = new STA_Statistics()
		{
			StatisticTypeCoded = "E",
			StatisticalDetails = null,
		};

		var actual = Map.MapObject<STA_Statistics>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredStatisticTypeCoded(string statisticTypeCoded, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		//Required fields
		//Test Parameters
		subject.StatisticTypeCoded = statisticTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
