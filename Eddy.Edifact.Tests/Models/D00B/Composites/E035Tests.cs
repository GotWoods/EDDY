using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E035Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "b:Y:2";

		var expected = new E035_QuantityDetails()
		{
			QuantityTypeCodeQualifier = "b",
			Quantity = "Y",
			MeasurementUnitCode = "2",
		};

		var actual = Map.MapComposite<E035_QuantityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredQuantityTypeCodeQualifier(string quantityTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new E035_QuantityDetails();
		//Required fields
		subject.Quantity = "Y";
		//Test Parameters
		subject.QuantityTypeCodeQualifier = quantityTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredQuantity(string quantity, bool isValidExpected)
	{
		var subject = new E035_QuantityDetails();
		//Required fields
		subject.QuantityTypeCodeQualifier = "b";
		//Test Parameters
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
