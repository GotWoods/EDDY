using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CTBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTB*xd*G*FW*1*V*G";

		var expected = new CTB_RestrictionsConditions()
		{
			RestrictionsConditionsQualifier = "xd",
			Description = "G",
			QuantityQualifier = "FW",
			Quantity = 1,
			AmountQualifierCode = "V",
			Amount = "G",
		};

		var actual = Map.MapObject<CTB_RestrictionsConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xd", true)]
	public void Validation_RequiredRestrictionsConditionsQualifier(string restrictionsConditionsQualifier, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = restrictionsConditionsQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "FW";
			subject.Quantity = 1;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "V";
			subject.Amount = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("FW", 1, true)]
	[InlineData("FW", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "xd";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "V";
			subject.Amount = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "G", true)]
	[InlineData("V", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "xd";
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "FW";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
