using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*YI*cd*8*L*S*n*7H*ye*z8*yD*H*9*e*x";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "YI",
			ReferenceIdentificationQualifier = "cd",
			ReferenceIdentification = "8",
			EntityTitle = "L",
			EntityPurpose = "S",
			EntityStatusCode = "n",
			TransactionSetPurposeCode = "7H",
			ReportTypeCode = "ye",
			SecurityLevelCode2 = "z8",
			AgencyQualifierCode = "yD",
			SourceSubqualifier = "H",
			AssignedNumber = 9,
			CertificationTypeCode = "e",
			ProposalDataDetailIdentifierCode = "x",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YI", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = securityLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "cd";
			subject.ReferenceIdentification = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cd", "8", true)]
	[InlineData("cd", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "YI";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
