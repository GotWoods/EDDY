using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class AT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT3*V*zs*8*qF*4*Qxp*9";

		var expected = new AT3_BillOfLadingRatesAndCharges()
		{
			AmountCharged = "V",
			FreightRateQualifier = "zs",
			FreightRate = 8,
			RatedAsQualifier = "qF",
			Quantity = 4,
			BillOfLadingChargeCode = "Qxp",
			PercentageAsDecimal = 9,
		};

		var actual = Map.MapObject<AT3_BillOfLadingRatesAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		//Test Parameters
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreightRateQualifier) || !string.IsNullOrEmpty(subject.FreightRateQualifier) || subject.FreightRate > 0)
		{
			subject.FreightRateQualifier = "zs";
			subject.FreightRate = 8;
		}
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "qF";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("zs", 8, true)]
	[InlineData("zs", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredFreightRateQualifier(string freightRateQualifier, decimal freightRate, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		subject.AmountCharged = "V";
		//Test Parameters
		subject.FreightRateQualifier = freightRateQualifier;
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "qF";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
}
