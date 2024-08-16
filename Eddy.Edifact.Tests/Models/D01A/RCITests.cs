using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01A;
using Eddy.Edifact.Models.D01A.Composites;

namespace Eddy.Edifact.Tests.Models.D01A;

public class RCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RCI+";

		var expected = new RCI_ReservationControlInformation()
		{
			ReservationControlInformation = null,
		};

		var actual = Map.MapObject<RCI_ReservationControlInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
