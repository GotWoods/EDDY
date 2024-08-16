using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C509Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:9:c:F:p:b";

		var expected = new C509_PriceInformation()
		{
			PriceCodeQualifier = "9",
			PriceAmount = "9",
			PriceTypeCode = "c",
			PriceSpecificationCode = "F",
			UnitPriceBasisQuantity = "p",
			MeasurementUnitCode = "b",
		};

		var actual = Map.MapComposite<C509_PriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredPriceCodeQualifier(string priceCodeQualifier, bool isValidExpected)
	{
		var subject = new C509_PriceInformation();
		//Required fields
		//Test Parameters
		subject.PriceCodeQualifier = priceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
