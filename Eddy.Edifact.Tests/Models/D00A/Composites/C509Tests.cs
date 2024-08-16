using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C509Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:v:j:c:M:2";

		var expected = new C509_PriceInformation()
		{
			PriceCodeQualifier = "X",
			PriceAmount = "v",
			PriceTypeCode = "j",
			PriceSpecificationCode = "c",
			UnitPriceBasisValue = "M",
			MeasurementUnitCode = "2",
		};

		var actual = Map.MapComposite<C509_PriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredPriceCodeQualifier(string priceCodeQualifier, bool isValidExpected)
	{
		var subject = new C509_PriceInformation();
		//Required fields
		//Test Parameters
		subject.PriceCodeQualifier = priceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
