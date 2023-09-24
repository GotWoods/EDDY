using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*I4*c1*Q*n*v*w*ta*60*ZZ*Ly*b*5";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "I4",
			ReferenceNumberQualifier = "c1",
			ReferenceNumber = "Q",
			EntityTitle = "n",
			EntityPurpose = "v",
			EntityStatusCode = "w",
			TransactionSetPurposeCode = "ta",
			ReportTypeCode = "60",
			SecurityLevelCode2 = "ZZ",
			AgencyQualifierCode = "Ly",
			CodeListReference = "b",
			AssignedNumber = 5,
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I4", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.ReferenceNumberQualifier = "c1";
		subject.ReferenceNumber = "Q";
		subject.SecurityLevelCode = securityLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c1", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "I4";
		subject.ReferenceNumber = "Q";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "I4";
		subject.ReferenceNumberQualifier = "c1";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
