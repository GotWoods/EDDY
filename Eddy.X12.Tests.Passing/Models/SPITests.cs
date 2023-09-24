using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*ax*YJ*Z*K*V*z*hC*V5*xO*ux*9*9*w*N*j6r5";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "ax",
			ReferenceIdentificationQualifier = "YJ",
			ReferenceIdentification = "Z",
			EntityTitle = "K",
			EntityPurpose = "V",
			EntityStatusCode = "z",
			TransactionSetPurposeCode = "hC",
			ReportTypeCode = "V5",
			SecurityLevelCode2 = "xO",
			AgencyQualifierCode = "ux",
			SourceSubqualifier = "9",
			AssignedNumber = 9,
			CertificationTypeCode = "w",
			ProposalDataDetailIdentifierCode = "N",
			HierarchicalStructureCode = "j6r5",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ax", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = securityLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("YJ", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("YJ", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "ax";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
