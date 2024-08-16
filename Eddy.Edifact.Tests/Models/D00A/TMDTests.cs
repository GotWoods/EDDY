using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TMD++Q+C";

		var expected = new TMD_TransportMovementDetails()
		{
			MovementType = null,
			EquipmentPlanDescription = "Q",
			HaulageArrangementsCode = "C",
		};

		var actual = Map.MapObject<TMD_TransportMovementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
