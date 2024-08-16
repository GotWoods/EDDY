using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C509Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:P:Y:L:E:h";

		var expected = new C509_PriceInformation()
		{
			PriceQualifier = "7",
			Price = "P",
			PriceTypeCoded = "Y",
			PriceTypeQualifier = "L",
			UnitPriceBasis = "E",
			MeasureUnitQualifier = "h",
		};

		var actual = Map.MapComposite<C509_PriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredPriceQualifier(string priceQualifier, bool isValidExpected)
	{
		var subject = new C509_PriceInformation();
		//Required fields
		//Test Parameters
		subject.PriceQualifier = priceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
