using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPI*p7*zM*Z*e*x*S*Dg*GV*eu";

		var expected = new SPI_SpecificationIdentifier()
		{
			SecurityLevelCode = "p7",
			ReferenceNumberQualifier = "zM",
			ReferenceNumber = "Z",
			EntityTitle = "e",
			EntityPurpose = "x",
			EntityStatusCode = "S",
			TransactionSetPurposeCode = "Dg",
			ReportTypeCode = "GV",
			SecurityLevelCode2 = "eu",
		};

		var actual = Map.MapObject<SPI_SpecificationIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p7", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.ReferenceNumberQualifier = "zM";
		subject.ReferenceNumber = "Z";
		subject.SecurityLevelCode = securityLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zM", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "p7";
		subject.ReferenceNumber = "Z";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new SPI_SpecificationIdentifier();
		subject.SecurityLevelCode = "p7";
		subject.ReferenceNumberQualifier = "zM";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
