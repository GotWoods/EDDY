using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class INVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "INV+w+o+t+H+";

		var expected = new INV_InventoryManagementRelatedDetails()
		{
			InventoryMovementDirectionCode = "w",
			InventoryTypeCode = "o",
			InventoryMovementReasonCode = "t",
			InventoryBalanceMethodCode = "H",
			Instruction = null,
		};

		var actual = Map.MapObject<INV_InventoryManagementRelatedDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
