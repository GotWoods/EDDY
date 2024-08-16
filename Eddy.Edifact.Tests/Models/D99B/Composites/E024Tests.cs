using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E024Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "g:4:x";

		var expected = new E024_SupportingEvidence()
		{
			SupportingEvidenceTypeCodeQualifier = "g",
			ReferenceIdentifier = "4",
			CommunicationMediumTypeCode = "x",
		};

		var actual = Map.MapComposite<E024_SupportingEvidence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredSupportingEvidenceTypeCodeQualifier(string supportingEvidenceTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new E024_SupportingEvidence();
		//Required fields
		subject.ReferenceIdentifier = "4";
		//Test Parameters
		subject.SupportingEvidenceTypeCodeQualifier = supportingEvidenceTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentifier(string referenceIdentifier, bool isValidExpected)
	{
		var subject = new E024_SupportingEvidence();
		//Required fields
		subject.SupportingEvidenceTypeCodeQualifier = "g";
		//Test Parameters
		subject.ReferenceIdentifier = referenceIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
