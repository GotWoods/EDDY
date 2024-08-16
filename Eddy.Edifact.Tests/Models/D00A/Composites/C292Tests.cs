using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C292Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:G:P";

		var expected = new C292_PriceChangeInformation()
		{
			PriceChangeTypeCode = "U",
			CodeListIdentificationCode = "G",
			CodeListResponsibleAgencyCode = "P",
		};

		var actual = Map.MapComposite<C292_PriceChangeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredPriceChangeTypeCode(string priceChangeTypeCode, bool isValidExpected)
	{
		var subject = new C292_PriceChangeInformation();
		//Required fields
		//Test Parameters
		subject.PriceChangeTypeCode = priceChangeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
