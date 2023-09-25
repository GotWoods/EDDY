using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class QTYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "QTY*aS*9**u";

		var expected = new QTY_Quantity()
		{
			QuantityQualifier = "aS",
			Quantity = 9,
			CompositeUnitOfMeasure = null,
			FreeFormMessage = "u",
		};

		var actual = Map.MapObject<QTY_Quantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aS", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new QTY_Quantity();
		//Required fields
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		//At Least one
		subject.Quantity = 9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(9, "", true)]
	[InlineData(0, "u", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string freeFormMessage, bool isValidExpected)
	{
		var subject = new QTY_Quantity();
		//Required fields
		subject.QuantityQualifier = "aS";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(9, "u", false)]
	[InlineData(9, "", true)]
	[InlineData(0, "u", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string freeFormMessage, bool isValidExpected)
	{
		var subject = new QTY_Quantity();
		//Required fields
		subject.QuantityQualifier = "aS";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
