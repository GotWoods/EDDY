using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class UDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UDA*HB*q*MJ*5*Na*7*6";

		var expected = new UDA_UnderwritingCondition()
		{
			OfferBasisCode = "HB",
			Description = "q",
			QuantityQualifier = "MJ",
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "Na",
			Amount = "7",
			Percent = 6,
		};

		var actual = Map.MapObject<UDA_UnderwritingCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HB", true)]
	public void Validation_RequiredOfferBasisCode(string offerBasisCode, bool isValidExpected)
	{
		var subject = new UDA_UnderwritingCondition();
		//Required fields
		//Test Parameters
		subject.OfferBasisCode = offerBasisCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "MJ";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("MJ", 5, true)]
	[InlineData("MJ", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new UDA_UnderwritingCondition();
		//Required fields
		subject.OfferBasisCode = "HB";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
