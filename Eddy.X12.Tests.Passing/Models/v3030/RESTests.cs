using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class RESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RES*7*X*VC*i*L*2V*2*Um*8C*2*i*6*Vm*gM*6*D*8*1ET*KqxELl*DOj*YJkygE";

		var expected = new RES_Resource()
		{
			ResourceCodeOrIdentifier = "7",
			Description = "X",
			ResourceType = "VC",
			ReferenceNumber = "i",
			ReferenceNumber2 = "L",
			QuantityQualifier = "2V",
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "Um",
			QuantityQualifier2 = "8C",
			Quantity2 = 2,
			AmountQualifierCode = "i",
			MonetaryAmount = 6,
			UnitOrBasisForMeasurementCode2 = "Vm",
			RateValueQualifier = "gM",
			Rate = 6,
			PercentQualifier = "D",
			Percent = 8,
			DateTimeQualifier = "1ET",
			Date = "KqxELl",
			DateTimeQualifier2 = "DOj",
			Date2 = "YJkygE",
		};

		var actual = Map.MapObject<RES_Resource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredResourceCodeOrIdentifier(string resourceCodeOrIdentifier, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		//Test Parameters
		subject.ResourceCodeOrIdentifier = resourceCodeOrIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "gM";
			subject.Rate = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("8C", 2, true)]
	[InlineData("8C", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		subject.ResourceCodeOrIdentifier = "7";
		//Test Parameters
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "gM";
			subject.Rate = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("gM", 6, true)]
	[InlineData("gM", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal rate, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		subject.ResourceCodeOrIdentifier = "7";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (rate > 0) 
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
