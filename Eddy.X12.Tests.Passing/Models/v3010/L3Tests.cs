using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L3*4*t*6*iJ*u*m*4*XLK*5*v*5*z*D*Jr*f3";

		var expected = new L3_TotalWeightAndCharges()
		{
			Weight = 4,
			WeightQualifier = "t",
			FreightRate = 6,
			RateValueQualifier = "iJ",
			Charge = "u",
			Advances = "m",
			PrepaidAmount = "4",
			SpecialChargeCode = "XLK",
			Volume = 5,
			VolumeUnitQualifier = "v",
			LadingQuantity = 5,
			WeightUnitQualifier = "z",
			TariffNumber = "D",
			DeclaredValue = "Jr",
			RateValueQualifier2 = "f3",
		};

		var actual = Map.MapObject<L3_TotalWeightAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
