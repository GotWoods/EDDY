using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RES*0*c*TR*n*H*2x*9**EN*2*P*2**5i*3*p*2*Xhl*TZDOMn*uj3*TtK2SI";

		var expected = new RES_Resource()
		{
			ResourceCodeOrIdentifier = "0",
			Description = "c",
			ResourceType = "TR",
			ReferenceIdentification = "n",
			ReferenceIdentification2 = "H",
			QuantityQualifier = "2x",
			Quantity = 9,
			CompositeUnitOfMeasure = null,
			QuantityQualifier2 = "EN",
			Quantity2 = 2,
			AmountQualifierCode = "P",
			MonetaryAmount = 2,
			CompositeUnitOfMeasure2 = null,
			RateValueQualifier = "5i",
			Rate = 3,
			PercentQualifier = "p",
			Percent = 2,
			DateTimeQualifier = "Xhl",
			Date = "TZDOMn",
			DateTimeQualifier2 = "uj3",
			Date2 = "TtK2SI",
		};

		var actual = Map.MapObject<RES_Resource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredResourceCodeOrIdentifier(string resourceCodeOrIdentifier, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		//Test Parameters
		subject.ResourceCodeOrIdentifier = resourceCodeOrIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "5i";
			subject.Rate = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("EN", 2, true)]
	[InlineData("EN", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		subject.ResourceCodeOrIdentifier = "0";
		//Test Parameters
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Rate > 0)
		{
			subject.RateValueQualifier = "5i";
			subject.Rate = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5i", 3, true)]
	[InlineData("5i", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal rate, bool isValidExpected)
	{
		var subject = new RES_Resource();
		//Required fields
		subject.ResourceCodeOrIdentifier = "0";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (rate > 0) 
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
