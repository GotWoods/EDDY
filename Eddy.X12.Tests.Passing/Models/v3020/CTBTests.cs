using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CTBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTB*9z*6*U6*3";

		var expected = new CTB_RestrictionsConditions()
		{
			RestrictionsConditionsQualifier = "9z",
			Description = "6",
			QuantityQualifier = "U6",
			Quantity = 3,
		};

		var actual = Map.MapObject<CTB_RestrictionsConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9z", true)]
	public void Validation_RequiredRestrictionsConditionsQualifier(string restrictionsConditionsQualifier, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = restrictionsConditionsQualifier;
			subject.Description = "6";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "U6";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("6", 3, true)]
	[InlineData("6", 0, true)]
	[InlineData("", 3, true)]
	public void Validation_AtLeastOneDescription(string description, decimal quantity, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "9z";
		subject.Description = description;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "U6";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U6", 3, true)]
	[InlineData("U6", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CTB_RestrictionsConditions();
		subject.RestrictionsConditionsQualifier = "9z";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
			subject.Quantity = quantity;
			subject.Description = "6";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
