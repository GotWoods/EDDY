using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C543Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "c:y:C:K:B";

		var expected = new C543_AgreementTypeIdentification()
		{
			AgreementTypeCodeQualifier = "c",
			AgreementTypeDescriptionCode = "y",
			CodeListIdentificationCode = "C",
			CodeListResponsibleAgencyCode = "K",
			AgreementTypeDescription = "B",
		};

		var actual = Map.MapComposite<C543_AgreementTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredAgreementTypeCodeQualifier(string agreementTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C543_AgreementTypeIdentification();
		//Required fields
		//Test Parameters
		subject.AgreementTypeCodeQualifier = agreementTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
