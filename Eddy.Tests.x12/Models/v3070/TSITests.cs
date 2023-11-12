using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSI*0*t*8*4";

		var expected = new TSI_AutomaticEquipmentTagStatusInformation()
		{
			TagStatusCode = "0",
			IndustryCode = "t",
			Quantity = 8,
			Quantity2 = 4,
		};

		var actual = Map.MapObject<TSI_AutomaticEquipmentTagStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
