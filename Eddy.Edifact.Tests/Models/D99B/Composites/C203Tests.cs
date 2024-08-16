using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C203Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:3:U:d:k:r:c:j:z:f";

		var expected = new C203_RateTariffClass()
		{
			RateTariffClassIdentification = "u",
			CodeListIdentificationCode = "3",
			CodeListResponsibleAgencyCode = "U",
			RateTariffClass = "d",
			SupplementaryRateTariffBasisIdentification = "k",
			CodeListIdentificationCode2 = "r",
			CodeListResponsibleAgencyCode2 = "c",
			SupplementaryRateTariffBasisIdentification2 = "j",
			CodeListIdentificationCode3 = "z",
			CodeListResponsibleAgencyCode3 = "f",
		};

		var actual = Map.MapComposite<C203_RateTariffClass>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredRateTariffClassIdentification(string rateTariffClassIdentification, bool isValidExpected)
	{
		var subject = new C203_RateTariffClass();
		//Required fields
		//Test Parameters
		subject.RateTariffClassIdentification = rateTariffClassIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
