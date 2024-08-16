using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TMD++N+D";

		var expected = new TMD_TransportMovementDetails()
		{
			MovementType = null,
			EquipmentPlan = "N",
			HaulageArrangementsCoded = "D",
		};

		var actual = Map.MapObject<TMD_TransportMovementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
