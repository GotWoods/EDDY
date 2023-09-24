using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*RW*zf*g*x*U*m*xu*DL*gI*3K*p*2*l*j*kjHt";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "RW",
			ReferenceIdentificationQualifier = "zf",
			ReferenceIdentification = "g",
			EntityTitle = "x",
			EntityPurpose = "U",
			EntityStatusCode = "m",
			TransactionSetPurposeCode = "xu",
			ReportTypeCode = "DL",
			SecurityLevelCode2 = "gI",
			AgencyQualifierCode = "3K",
			SourceSubqualifier = "p",
			AssignedNumber = 2,
			CertificationTypeCode = "l",
			ProposalDataDetailIdentifierCode = "j",
			HierarchicalStructureCode = "kjHt",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RW", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = securityLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "zf";
			subject.ReferenceIdentification = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zf", "g", true)]
	[InlineData("zf", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "RW";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
