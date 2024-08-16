using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E083Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:a:E:B:Z:u:Z:W";

		var expected = new E083_DeliveryPattern()
		{
			QuantityTypeCodeQualifier = "x",
			Quantity = "a",
			MeasurementUnitCode = "E",
			Quantity2 = "B",
			PeriodTypeCode = "Z",
			PeriodCountQuantity = "u",
			DespatchPatternCode = "Z",
			DespatchPatternTimingCode = "W",
		};

		var actual = Map.MapComposite<E083_DeliveryPattern>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredQuantityTypeCodeQualifier(string quantityTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new E083_DeliveryPattern();
		//Required fields
		//Test Parameters
		subject.QuantityTypeCodeQualifier = quantityTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
