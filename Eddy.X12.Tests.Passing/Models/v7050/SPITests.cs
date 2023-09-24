using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*J4*r7*E*8*4*r*id*Mb*JJ*6w*y*3*a*f*p1iL";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "J4",
			ReferenceIdentificationQualifier = "r7",
			ReferenceIdentification = "E",
			EntityTitle = "8",
			EntityPurpose = "4",
			EntityStatusCode = "r",
			TransactionSetPurposeCode = "id",
			ReportTypeCode = "Mb",
			SecurityLevelCode2 = "JJ",
			AgencyQualifierCode = "6w",
			SourceSubqualifier = "y",
			AssignedNumber = 3,
			CertificationTypeCode = "a",
			ProposalDataDetailIdentifierCode = "f",
			HierarchicalStructureCode = "p1iL",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J4", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = securityLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "r7";
			subject.ReferenceIdentification = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r7", "E", true)]
	[InlineData("r7", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "J4";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
