using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*Wu*cE*X*N*I*9*FG*uF*fT*vY*D*9*I*b";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "Wu",
			ReferenceNumberQualifier = "cE",
			ReferenceNumber = "X",
			EntityTitle = "N",
			EntityPurpose = "I",
			EntityStatusCode = "9",
			TransactionSetPurposeCode = "FG",
			ReportTypeCode = "uF",
			SecurityLevelCode2 = "fT",
			AgencyQualifierCode = "vY",
			SourceSubqualifier = "D",
			AssignedNumber = 9,
			CertificationTypeCode = "I",
			ProposalDataDetailIdentifierCode = "b",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wu", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.ReferenceNumberQualifier = "cE";
		subject.ReferenceNumber = "X";
		subject.SecurityLevelCode = securityLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cE", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "Wu";
		subject.ReferenceNumber = "X";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "Wu";
		subject.ReferenceNumberQualifier = "cE";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
