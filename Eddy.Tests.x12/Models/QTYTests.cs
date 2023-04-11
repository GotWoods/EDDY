using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class QTYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "QTY*n0*3**c";

		var expected = new QTY_QuantityInformation()
		{
			QuantityQualifier = "n0",
			Quantity = 3,
			CompositeUnitOfMeasure = "",
			FreeFormInformation = "c",
		};

		var actual = Map.MapObject<QTY_QuantityInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n0", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new QTY_QuantityInformation();
		subject.QuantityQualifier = quantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", false)]
	[InlineData(3,"c", true)]
	[InlineData(0, "c", true)]
	[InlineData(3, "", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string freeFormInformation, bool isValidExpected)
	{
		var subject = new QTY_QuantityInformation();
		subject.QuantityQualifier = "n0";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "c", false)]
	[InlineData(0, "c", true)]
	[InlineData(3, "", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string freeFormInformation, bool isValidExpected)
	{
		var subject = new QTY_QuantityInformation();
		subject.QuantityQualifier = "n0";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
