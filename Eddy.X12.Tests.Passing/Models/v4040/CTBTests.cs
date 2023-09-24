using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CTBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTB*kh*Y*DO*2*r*v*";

		var expected = new CTB_RestrictionsConditions()
		{
			RestrictionsConditionsQualifier = "kh",
			Description = "Y",
			QuantityQualifier = "DO",
			Quantity = 2,
			AmountQualifierCode = "r",
			Amount = "v",
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<CTB_RestrictionsConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kh", true)]
	public void Validation_RequiredRestrictionsConditionsQualifier(string restrictionsConditionsQualifier, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = restrictionsConditionsQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "DO";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "r";
			subject.Amount = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("DO", 2, true)]
	[InlineData("DO", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "kh";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "r";
			subject.Amount = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "v", true)]
	[InlineData("r", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "kh";
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "DO";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
