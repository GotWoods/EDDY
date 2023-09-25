using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class QTYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "QTY*dC*2**s";

		var expected = new QTY_QuantityInformation()
		{
			QuantityQualifier = "dC",
			Quantity = 2,
			CompositeUnitOfMeasure = null,
			FreeFormInformation = "s",
		};

		var actual = Map.MapObject<QTY_QuantityInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dC", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new QTY_QuantityInformation();
		//Required fields
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		//At Least one
		subject.Quantity = 2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(2, "", true)]
	[InlineData(0, "s", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string freeFormInformation, bool isValidExpected)
	{
		var subject = new QTY_QuantityInformation();
		//Required fields
		subject.QuantityQualifier = "dC";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FreeFormInformation = freeFormInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(2, "s", false)]
	[InlineData(2, "", true)]
	[InlineData(0, "s", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string freeFormInformation, bool isValidExpected)
	{
		var subject = new QTY_QuantityInformation();
		//Required fields
		subject.QuantityQualifier = "dC";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FreeFormInformation = freeFormInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
