using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*ju*c1*F*J*s*F*Ep*Dc*Zm*M6*i*8*X*w*c3YN";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "ju",
			ReferenceIdentificationQualifier = "c1",
			ReferenceIdentification = "F",
			EntityTitle = "J",
			EntityPurpose = "s",
			EntityStatusCode = "F",
			TransactionSetPurposeCode = "Ep",
			ReportTypeCode = "Dc",
			SecurityLevelCode2 = "Zm",
			AgencyQualifierCode = "M6",
			SourceSubqualifier = "i",
			AssignedNumber = 8,
			CertificationTypeCode = "X",
			ProposalDataDetailIdentifierCode = "w",
			HierarchicalStructureCode = "c3YN",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ju", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = securityLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "c1";
			subject.ReferenceIdentification = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c1", "F", true)]
	[InlineData("c1", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "ju";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
