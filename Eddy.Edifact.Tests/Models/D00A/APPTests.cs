using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class APPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "APP+T+";

		var expected = new APP_Applicability()
		{
			ApplicabilityCodeQualifier = "T",
			ApplicabilityType = null,
		};

		var actual = Map.MapObject<APP_Applicability>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
