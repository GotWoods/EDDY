using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class INVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "INV+r+u+D+N+";

		var expected = new INV_InventoryManagementRelatedDetails()
		{
			InventoryMovementDirectionCoded = "r",
			TypeOfInventoryAffectedCoded = "u",
			ReasonForInventoryMovementCoded = "D",
			InventoryBalanceMethodCoded = "N",
			Instruction = null,
		};

		var actual = Map.MapObject<INV_InventoryManagementRelatedDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
