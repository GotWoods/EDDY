using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class RCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RCI+";

		var expected = new RCI_ReservationControlInformation()
		{
			ReservationControlIdentification = null,
		};

		var actual = Map.MapObject<RCI_ReservationControlInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
