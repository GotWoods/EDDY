using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060.Composites;

public class C065Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "F*m*g*p*4*a*Y*y*7*D";

		var expected = new C065_ProductUnitIndicator()
		{
			YesNoConditionOrResponseCode = "F",
			YesNoConditionOrResponseCode2 = "m",
			YesNoConditionOrResponseCode3 = "g",
			YesNoConditionOrResponseCode4 = "p",
			YesNoConditionOrResponseCode5 = "4",
			YesNoConditionOrResponseCode6 = "a",
			YesNoConditionOrResponseCode7 = "Y",
			YesNoConditionOrResponseCode8 = "y",
			YesNoConditionOrResponseCode9 = "7",
			YesNoConditionOrResponseCode10 = "D",
		};

		var actual = Map.MapObject<C065_ProductUnitIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
