using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C203Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:i:I:x:w:M:L:F:4:R";

		var expected = new C203_RateTariffClass()
		{
			RateOrTariffClassDescriptionCode = "U",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "I",
			RateOrTariffClassDescription = "x",
			SupplementaryRateOrTariffCode = "w",
			CodeListIdentificationCode2 = "M",
			CodeListResponsibleAgencyCode2 = "L",
			SupplementaryRateOrTariffCode2 = "F",
			CodeListIdentificationCode3 = "4",
			CodeListResponsibleAgencyCode3 = "R",
		};

		var actual = Map.MapComposite<C203_RateTariffClass>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredRateOrTariffClassDescriptionCode(string rateOrTariffClassDescriptionCode, bool isValidExpected)
	{
		var subject = new C203_RateTariffClass();
		//Required fields
		//Test Parameters
		subject.RateOrTariffClassDescriptionCode = rateOrTariffClassDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
