using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1*4*8*Oq*H*R*X*bbR*bH7*R*K*4*Gw*T*J8*rY*r";

		var expected = new L1_RateAndCharges()
		{
			LadingLineItemNumber = 4,
			FreightRate = 8,
			RateValueQualifier = "Oq",
			Charge = "H",
			Advances = "R",
			PrepaidAmount = "X",
			RateCombinationPointCode = "bbR",
			SpecialChargeCode = "bH7",
			RateClassCode = "R",
			EntitlementCode = "K",
			ChargeMethodOfPayment = "4",
			SpecialChargeDescription = "Gw",
			TariffApplicationCode = "T",
			DeclaredValue = "J8",
			RateValueQualifier2 = "rY",
			LadingLiabilityCode = "r",
		};

		var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
