using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E083Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:t:W:7:0:r:X:h";

		var expected = new E083_DeliveryPattern()
		{
			QuantityTypeCodeQualifier = "P",
			Quantity = "t",
			MeasurementUnitCode = "W",
			Quantity2 = "7",
			PeriodTypeCode = "0",
			PeriodCountQuantity = "r",
			DespatchPatternCode = "X",
			DespatchPatternTimingCode = "h",
		};

		var actual = Map.MapComposite<E083_DeliveryPattern>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredQuantityTypeCodeQualifier(string quantityTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new E083_DeliveryPattern();
		//Required fields
		//Test Parameters
		subject.QuantityTypeCodeQualifier = quantityTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
