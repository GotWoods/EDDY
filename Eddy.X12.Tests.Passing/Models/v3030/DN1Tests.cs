using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DN1*6*1*5*L";

		var expected = new DN1_OrthodonticInformation()
		{
			Quantity = 6,
			Quantity2 = 1,
			YesNoConditionOrResponseCode = "5",
			Description = "L",
		};

		var actual = Map.MapObject<DN1_OrthodonticInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
