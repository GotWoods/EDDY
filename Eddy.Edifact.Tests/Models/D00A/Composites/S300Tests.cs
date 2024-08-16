using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S300Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:X:F2Ef";

		var expected = new S300_DateAndOrTimeOfInitiation()
		{
			EventDate = "t",
			EventTime = "X",
			TimeOffset = "F2Ef",
		};

		var actual = Map.MapComposite<S300_DateAndOrTimeOfInitiation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
