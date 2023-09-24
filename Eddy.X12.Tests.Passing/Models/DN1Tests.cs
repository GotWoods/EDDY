using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DN1*6*1*N*S";

		var expected = new DN1_OrthodonticInformation()
		{
			Quantity = 6,
			Quantity2 = 1,
			YesNoConditionOrResponseCode = "N",
			Description = "S",
		};

		var actual = Map.MapObject<DN1_OrthodonticInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
