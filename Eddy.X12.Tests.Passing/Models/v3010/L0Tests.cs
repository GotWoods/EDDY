using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L0*5*4*AI*4*v*7*j*1*vEu*0n*E*Jj";

		var expected = new L0_LineItemQuantityAndWeight()
		{
			LadingLineItemNumber = 5,
			BilledRatedAsQuantity = 4,
			BilledRatedAsQualifier = "AI",
			Weight = 4,
			WeightQualifier = "v",
			Volume = 7,
			VolumeUnitQualifier = "j",
			LadingQuantity = 1,
			LadingQuantityQualifier = "vEu",
			DunnageDescription = "0n",
			WeightUnitQualifier = "E",
			TypeOfServiceCode = "Jj",
		};

		var actual = Map.MapObject<L0_LineItemQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
