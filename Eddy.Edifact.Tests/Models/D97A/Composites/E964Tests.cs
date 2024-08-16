using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E964Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "0lq0:vi3Y:y";

		var expected = new E964_TravellerTimeDetails()
		{
			Time = "0lq0",
			Time2 = "vi3Y",
			CheckInDateAndTime = "y",
		};

		var actual = Map.MapComposite<E964_TravellerTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
