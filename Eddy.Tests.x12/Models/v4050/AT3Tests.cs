using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class AT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT3*w*P5*5*qv*1*nym*1";

		var expected = new AT3_BillOfLadingRatesAndCharges()
		{
			AmountCharged = "w",
			FreightRateQualifier = "P5",
			FreightRate = 5,
			RatedAsQualifier = "qv",
			Quantity = 1,
			BillOfLadingChargeCode = "nym",
			PercentageAsDecimal = 1,
		};

		var actual = Map.MapObject<AT3_BillOfLadingRatesAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		//Test Parameters
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreightRateQualifier) || !string.IsNullOrEmpty(subject.FreightRateQualifier) || subject.FreightRate > 0)
		{
			subject.FreightRateQualifier = "P5";
			subject.FreightRate = 5;
		}
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "qv";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("P5", 5, true)]
	[InlineData("P5", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredFreightRateQualifier(string freightRateQualifier, decimal freightRate, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		subject.AmountCharged = "w";
		//Test Parameters
		subject.FreightRateQualifier = freightRateQualifier;
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "qv";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	

}
