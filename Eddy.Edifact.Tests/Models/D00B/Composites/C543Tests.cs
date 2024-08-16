using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C543Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "h:Q:z:m:C";

		var expected = new C543_AgreementTypeIdentification()
		{
			AgreementTypeCodeQualifier = "h",
			AgreementTypeDescriptionCode = "Q",
			CodeListIdentificationCode = "z",
			CodeListResponsibleAgencyCode = "m",
			AgreementTypeDescription = "C",
		};

		var actual = Map.MapComposite<C543_AgreementTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredAgreementTypeCodeQualifier(string agreementTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C543_AgreementTypeIdentification();
		//Required fields
		//Test Parameters
		subject.AgreementTypeCodeQualifier = agreementTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
