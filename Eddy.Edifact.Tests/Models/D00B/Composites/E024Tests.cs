using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E024Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:0:c";

		var expected = new E024_SupportingEvidence()
		{
			SupportingEvidenceTypeCodeQualifier = "U",
			ReferenceIdentifier = "0",
			CommunicationMediumTypeCode = "c",
		};

		var actual = Map.MapComposite<E024_SupportingEvidence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredSupportingEvidenceTypeCodeQualifier(string supportingEvidenceTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new E024_SupportingEvidence();
		//Required fields
		subject.ReferenceIdentifier = "0";
		//Test Parameters
		subject.SupportingEvidenceTypeCodeQualifier = supportingEvidenceTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentifier(string referenceIdentifier, bool isValidExpected)
	{
		var subject = new E024_SupportingEvidence();
		//Required fields
		subject.SupportingEvidenceTypeCodeQualifier = "U";
		//Test Parameters
		subject.ReferenceIdentifier = referenceIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
