using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E035Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:M:N";

		var expected = new E035_QuantityDetails()
		{
			QuantityTypeCodeQualifier = "w",
			Quantity = "M",
			MeasurementUnitCode = "N",
		};

		var actual = Map.MapComposite<E035_QuantityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredQuantityTypeCodeQualifier(string quantityTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new E035_QuantityDetails();
		//Required fields
		subject.Quantity = "M";
		//Test Parameters
		subject.QuantityTypeCodeQualifier = quantityTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredQuantity(string quantity, bool isValidExpected)
	{
		var subject = new E035_QuantityDetails();
		//Required fields
		subject.QuantityTypeCodeQualifier = "w";
		//Test Parameters
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
