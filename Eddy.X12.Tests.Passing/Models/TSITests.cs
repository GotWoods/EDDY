using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSI*P*P*6*3";

		var expected = new TSI_AutomaticEquipmentTagStatusInformation()
		{
			TagStatusCode = "P",
			IndustryCode = "P",
			Quantity = 6,
			Quantity2 = 3,
		};

		var actual = Map.MapObject<TSI_AutomaticEquipmentTagStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
