using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class UDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UDA*Xi*s*co*1*ZX*T*4";

		var expected = new UDA_UnderwritingCondition()
		{
			OfferBasisCode = "Xi",
			Description = "s",
			QuantityQualifier = "co",
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "ZX",
			Amount = "T",
			PercentageAsDecimal = 4,
		};

		var actual = Map.MapObject<UDA_UnderwritingCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xi", true)]
	public void Validation_RequiredOfferBasisCode(string offerBasisCode, bool isValidExpected)
	{
		var subject = new UDA_UnderwritingCondition();
		//Required fields
		//Test Parameters
		subject.OfferBasisCode = offerBasisCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "co";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("co", 1, true)]
	[InlineData("co", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new UDA_UnderwritingCondition();
		//Required fields
		subject.OfferBasisCode = "Xi";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
