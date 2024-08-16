using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class STATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STA+e+";

		var expected = new STA_Statistics()
		{
			StatisticTypeCodeQualifier = "e",
			StatisticalDetails = null,
		};

		var actual = Map.MapObject<STA_Statistics>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredStatisticTypeCodeQualifier(string statisticTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		//Required fields
		//Test Parameters
		subject.StatisticTypeCodeQualifier = statisticTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
