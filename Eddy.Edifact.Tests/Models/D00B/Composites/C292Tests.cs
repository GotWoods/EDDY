using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C292Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:R:f";

		var expected = new C292_PriceChangeInformation()
		{
			PriceChangeTypeCode = "k",
			CodeListIdentificationCode = "R",
			CodeListResponsibleAgencyCode = "f",
		};

		var actual = Map.MapComposite<C292_PriceChangeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredPriceChangeTypeCode(string priceChangeTypeCode, bool isValidExpected)
	{
		var subject = new C292_PriceChangeInformation();
		//Required fields
		//Test Parameters
		subject.PriceChangeTypeCode = priceChangeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
