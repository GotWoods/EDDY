using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class AT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT3*9*Cz*1*jO*7*yPe*9";

		var expected = new AT3_BillOfLadingRatesAndCharges()
		{
			AmountCharged = "9",
			FreightRateQualifier = "Cz",
			FreightRate = 1,
			RatedAsQualifier = "jO",
			Quantity = 7,
			BillOfLadingChargeCode = "yPe",
			PercentageAsDecimal = 9,
		};

		var actual = Map.MapObject<AT3_BillOfLadingRatesAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		//Test Parameters
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreightRateQualifier) || !string.IsNullOrEmpty(subject.FreightRateQualifier) || subject.FreightRate > 0)
		{
			subject.FreightRateQualifier = "Cz";
			subject.FreightRate = 1;
		}
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "jO";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Cz", 1, true)]
	[InlineData("Cz", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredFreightRateQualifier(string freightRateQualifier, decimal freightRate, bool isValidExpected)
	{
		var subject = new AT3_BillOfLadingRatesAndCharges();
		//Required fields
		subject.AmountCharged = "9";
		//Test Parameters
		subject.FreightRateQualifier = freightRateQualifier;
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RatedAsQualifier) || !string.IsNullOrEmpty(subject.RatedAsQualifier) || subject.Quantity > 0)
		{
			subject.RatedAsQualifier = "jO";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}



}
