using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CTBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTB*hB*Y*kZ*5*p*f*";

		var expected = new CTB_RestrictionsConditions()
		{
			RestrictionsConditionsQualifier = "hB",
			Description = "Y",
			QuantityQualifier = "kZ",
			Quantity = 5,
			AmountQualifierCode = "p",
			Amount = "f",
			CompositeUnitOfMeasure = "",
		};

		var actual = Map.MapObject<CTB_RestrictionsConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hB", true)]
	public void Validatation_RequiredRestrictionsConditionsQualifier(string restrictionsConditionsQualifier, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = restrictionsConditionsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("kZ", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("kZ", 0, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "hB";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("p", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "hB";
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
