using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT3*X*7D*1*pv*7*zAA*8";

		var expected = new AT3_BillOfLadingRatesAndCharges()
		{
			Charge = "X",
			FreightRateQualifier = "7D",
			FreightRate = 1,
			RatedAsQualifier = "pv",
			Quantity = 7,
			BillOfLadingChargeCode = "zAA",
			Percent = 8,
		};

		var actual = Map.MapObject<AT3_BillOfLadingRatesAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		//Test Parameters
		subject.Charge = charge;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreightRateQualifier) || !string.IsNullOrEmpty(subject.FreightRateQualifier) || subject.FreightRate > 0)
		{
			subject.FreightRateQualifier = "7D";
			subject.FreightRate = 1;
		}
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "pv";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7D", 1, true)]
	[InlineData("7D", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredFreightRateQualifier(string freightRateQualifier, decimal freightRate, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		subject.Charge = "X";
		//Test Parameters
		subject.FreightRateQualifier = freightRateQualifier;
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "pv";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("pv", 7, true)]
	[InlineData("pv", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredRatedAsQualifier(string ratedAsQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		subject.Charge = "X";
		//Test Parameters
		subject.RatedAsQualifier = ratedAsQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.FreightRateQualifier) || subject.FreightRate > 0)
		{
			subject.FreightRateQualifier = "7D";
			subject.FreightRate = 1;
		}

		

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	
}
