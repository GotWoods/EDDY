using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C203Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "h:y:3:k:H:I:S:L:i:n";

		var expected = new C203_RateTariffClass()
		{
			RateTariffClassIdentification = "h",
			CodeListQualifier = "y",
			CodeListResponsibleAgencyCoded = "3",
			RateTariffClass = "k",
			SupplementaryRateTariffBasisIdentification = "H",
			CodeListQualifier2 = "I",
			CodeListResponsibleAgencyCoded2 = "S",
			SupplementaryRateTariffBasisIdentification2 = "L",
			CodeListQualifier3 = "i",
			CodeListResponsibleAgencyCoded3 = "n",
		};

		var actual = Map.MapComposite<C203_RateTariffClass>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredRateTariffClassIdentification(string rateTariffClassIdentification, bool isValidExpected)
	{
		var subject = new C203_RateTariffClass();
		//Required fields
		//Test Parameters
		subject.RateTariffClassIdentification = rateTariffClassIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
