using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E964Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U6k8:FHM3:O";

		var expected = new E964_TravellerTimeDetails()
		{
			Time = "U6k8",
			Time2 = "FHM3",
			CheckInTime = "O",
		};

		var actual = Map.MapComposite<E964_TravellerTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
