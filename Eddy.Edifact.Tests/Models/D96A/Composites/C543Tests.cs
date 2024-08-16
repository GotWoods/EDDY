using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C543Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:f:u:C:9";

		var expected = new C543_AgreementTypeIdentification()
		{
			AgreementTypeQualifier = "9",
			AgreementTypeCoded = "f",
			CodeListQualifier = "u",
			CodeListResponsibleAgencyCoded = "C",
			AgreementTypeDescription = "9",
		};

		var actual = Map.MapComposite<C543_AgreementTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAgreementTypeQualifier(string agreementTypeQualifier, bool isValidExpected)
	{
		var subject = new C543_AgreementTypeIdentification();
		//Required fields
		//Test Parameters
		subject.AgreementTypeQualifier = agreementTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
