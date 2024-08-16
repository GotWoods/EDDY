using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ARRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ARR++";

		var expected = new ARR_ArrayInformation()
		{
			PositionIdentification = null,
			ArrayCellDetails = null,
		};

		var actual = Map.MapObject<ARR_ArrayInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
