using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*5a*3X*W*8*E*i*3Y*9R*Za*b3*r*3*7*x";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "5a",
			ReferenceNumberQualifier = "3X",
			ReferenceNumber = "W",
			EntityTitle = "8",
			EntityPurpose = "E",
			EntityStatusCode = "i",
			TransactionSetPurposeCode = "3Y",
			ReportTypeCode = "9R",
			SecurityLevelCode2 = "Za",
			AgencyQualifierCode = "b3",
			SourceSubqualifier = "r",
			AssignedNumber = 3,
			CertificationTypeCode = "7",
			ProposalDataDetailIdentifierCode = "x",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5a", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = securityLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "3X";
			subject.ReferenceNumber = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3X", "W", true)]
	[InlineData("3X", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "5a";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
