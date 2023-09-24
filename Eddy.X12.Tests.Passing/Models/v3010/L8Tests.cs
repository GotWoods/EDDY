using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L8*5*ib*9*0*e*5*k5*x*opD*AO*C";

		var expected = new L8_LineItemSubtotal()
		{
			BilledRatedAsQuantity = 5,
			BilledRatedAsQualifier = "ib",
			Weight = 9,
			WeightUnitQualifier = "0",
			WeightQualifier = "e",
			FreightRate = 5,
			RateValueQualifier = "k5",
			Charge = "x",
			SpecialChargeCode = "opD",
			SpecialChargeDescription = "AO",
			ChargeMethodOfPayment = "C",
		};

		var actual = Map.MapObject<L8_LineItemSubtotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
