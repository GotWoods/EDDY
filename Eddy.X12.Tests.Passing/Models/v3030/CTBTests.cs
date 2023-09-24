using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CTBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTB*st*H*iY*9*J*R";

		var expected = new CTB_RestrictionsConditions()
		{
			RestrictionsConditionsQualifier = "st",
			Description = "H",
			QuantityQualifier = "iY",
			Quantity = 9,
			AmountQualifierCode = "J",
			Amount = "R",
		};

		var actual = Map.MapObject<CTB_RestrictionsConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("st", true)]
	public void Validation_RequiredRestrictionsConditionsQualifier(string restrictionsConditionsQualifier, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = restrictionsConditionsQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "iY";
			subject.Quantity = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "J";
			subject.Amount = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("iY", 9, true)]
	[InlineData("iY", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "st";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "J";
			subject.Amount = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "R", true)]
	[InlineData("J", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "st";
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "iY";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
