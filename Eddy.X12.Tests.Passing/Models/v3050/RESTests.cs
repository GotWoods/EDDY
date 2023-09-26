using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RES*N*e*Y4*v*e*L1*4*2a*mN*4*V*7*32*Ac*9*j*7*pFH*TsZ8hb*leA*PtODOV";

		var expected = new RES_Resource()
		{
			ResourceCodeOrIdentifier = "N",
			Description = "e",
			ResourceType = "Y4",
			ReferenceNumber = "v",
			ReferenceNumber2 = "e",
			QuantityQualifier = "L1",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "2a",
			QuantityQualifier2 = "mN",
			Quantity2 = 4,
			AmountQualifierCode = "V",
			MonetaryAmount = 7,
			UnitOrBasisForMeasurementCode2 = "32",
			RateValueQualifier = "Ac",
			Rate = 9,
			PercentQualifier = "j",
			Percent = 7,
			DateTimeQualifier = "pFH",
			Date = "TsZ8hb",
			DateTimeQualifier2 = "leA",
			Date2 = "PtODOV",
		};

		var actual = Map.MapObject<RES_Resource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredResourceCodeOrIdentifier(string resourceCodeOrIdentifier, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		//Test Parameters
		subject.ResourceCodeOrIdentifier = resourceCodeOrIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "Ac";
			subject.Rate = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("mN", 4, true)]
	[InlineData("mN", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		subject.ResourceCodeOrIdentifier = "N";
		//Test Parameters
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "Ac";
			subject.Rate = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ac", 9, true)]
	[InlineData("Ac", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal rate, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		subject.ResourceCodeOrIdentifier = "N";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (rate > 0) 
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
