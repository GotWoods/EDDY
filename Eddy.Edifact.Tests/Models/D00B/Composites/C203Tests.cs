using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C203Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:2:F:V:N:H:W:w:V:P";

		var expected = new C203_RateTariffClass()
		{
			RateOrTariffClassDescriptionCode = "U",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "F",
			RateOrTariffClassDescription = "V",
			SupplementaryRateOrTariffCode = "N",
			CodeListIdentificationCode2 = "H",
			CodeListResponsibleAgencyCode2 = "W",
			SupplementaryRateOrTariffCode2 = "w",
			CodeListIdentificationCode3 = "V",
			CodeListResponsibleAgencyCode3 = "P",
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
