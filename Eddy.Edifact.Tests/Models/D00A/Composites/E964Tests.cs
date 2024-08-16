using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E964Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "yL0l:lBhc:m";

		var expected = new E964_TravellerTimeDetails()
		{
			TimeValue = "yL0l",
			TimeValue2 = "lBhc",
			CheckInDateOrTimeValue = "m",
		};

		var actual = Map.MapComposite<E964_TravellerTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
