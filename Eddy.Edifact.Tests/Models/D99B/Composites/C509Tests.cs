using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C509Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "e:i:i:p:V:D";

		var expected = new C509_PriceInformation()
		{
			PriceQualifier = "e",
			Price = "i",
			PriceTypeCoded = "i",
			PriceSpecificationCode = "p",
			UnitPriceBasis = "V",
			MeasurementUnitCode = "D",
		};

		var actual = Map.MapComposite<C509_PriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPriceQualifier(string priceQualifier, bool isValidExpected)
	{
		var subject = new C509_PriceInformation();
		//Required fields
		//Test Parameters
		subject.PriceQualifier = priceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
