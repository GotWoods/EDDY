using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C292Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:z:i";

		var expected = new C292_PriceChangeInformation()
		{
			PriceChangeIndicatorCoded = "P",
			CodeListIdentificationCode = "z",
			CodeListResponsibleAgencyCode = "i",
		};

		var actual = Map.MapComposite<C292_PriceChangeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredPriceChangeIndicatorCoded(string priceChangeIndicatorCoded, bool isValidExpected)
	{
		var subject = new C292_PriceChangeInformation();
		//Required fields
		//Test Parameters
		subject.PriceChangeIndicatorCoded = priceChangeIndicatorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
