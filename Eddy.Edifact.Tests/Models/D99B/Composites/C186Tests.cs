using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C186Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:v:Y";

		var expected = new C186_QuantityDetails()
		{
			QuantityTypeCodeQualifier = "C",
			Quantity = "v",
			MeasurementUnitCode = "Y",
		};

		var actual = Map.MapComposite<C186_QuantityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredQuantityTypeCodeQualifier(string quantityTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C186_QuantityDetails();
		//Required fields
		subject.Quantity = "v";
		//Test Parameters
		subject.QuantityTypeCodeQualifier = quantityTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredQuantity(string quantity, bool isValidExpected)
	{
		var subject = new C186_QuantityDetails();
		//Required fields
		subject.QuantityTypeCodeQualifier = "C";
		//Test Parameters
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
