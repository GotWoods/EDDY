using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class C509Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "0:q:M:g:L:h";

		var expected = new C509_PriceInformation()
		{
			PriceCodeQualifier = "0",
			PriceAmount = "q",
			PriceTypeCode = "M",
			PriceSpecificationCode = "g",
			UnitPriceBasisQuantity = "L",
			MeasurementUnitCode = "h",
		};

		var actual = Map.MapComposite<C509_PriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredPriceCodeQualifier(string priceCodeQualifier, bool isValidExpected)
	{
		var subject = new C509_PriceInformation();
		//Required fields
		//Test Parameters
		subject.PriceCodeQualifier = priceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
