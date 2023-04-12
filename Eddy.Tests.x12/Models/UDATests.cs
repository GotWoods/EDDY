using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class UDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UDA*ub*6*oN*4*qC*1*1";

		var expected = new UDA_UnderwritingCondition()
		{
			OfferBasisCode = "ub",
			Description = "6",
			QuantityQualifier = "oN",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "qC",
			Amount = "1",
			PercentageAsDecimal = 1,
		};

		var actual = Map.MapObject<UDA_UnderwritingCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ub", true)]
	public void Validation_RequiredOfferBasisCode(string offerBasisCode, bool isValidExpected)
	{
		var subject = new UDA_UnderwritingCondition();
		subject.OfferBasisCode = offerBasisCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("oN", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("oN", 0, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new UDA_UnderwritingCondition();
		subject.OfferBasisCode = "ub";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
