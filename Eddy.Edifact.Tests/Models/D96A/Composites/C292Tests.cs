using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C292Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "W:q:8";

		var expected = new C292_PriceChangeInformation()
		{
			PriceChangeIndicatorCoded = "W",
			CodeListQualifier = "q",
			CodeListResponsibleAgencyCoded = "8",
		};

		var actual = Map.MapComposite<C292_PriceChangeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredPriceChangeIndicatorCoded(string priceChangeIndicatorCoded, bool isValidExpected)
	{
		var subject = new C292_PriceChangeInformation();
		//Required fields
		//Test Parameters
		subject.PriceChangeIndicatorCoded = priceChangeIndicatorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
