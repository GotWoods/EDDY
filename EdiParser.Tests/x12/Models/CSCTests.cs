using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class CSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSC*iCj*1*S*AA>A11>A22>A33*BB>B1*hfx*G*m*CCC>C1";

		var expected = new CSC_CryptographicServiceMessageCertificatesAndKeys()
		{
			CryptographicManagementPurposeCode = "iCj",
			SecurityOriginatorName = "1",
			SecurityRecipientName = "S",
			CertificateLookUpInformation = new C050_CertificateLookUpInformation() { LookUpValueProtocolCode = "AA", FilterIDCode = "A11", VersionIdentifier = "A22", LookUpValue = "A33"},
			ReferenceIdentifier = new C040_ReferenceIdentifier() { ReferenceIdentificationQualifier = "BB", ReferenceIdentification = "B1"},
			FilterIDCode = "hfx",
			VersionIdentifier = "G",
			LengthOfData = "m",
			SecurityTokenValue = new C033_SecurityTokenValue() { SecurityValueQualifier = "CCC", EncodedSecurityValue = "C1"},
		};

		var actual = Map.MapObject<CSC_CryptographicServiceMessageCertificatesAndKeys>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        //
        // if (!actual.CertificateLookUpInformation.ValidationResult.IsValid)
        //     Assert.Fail(actual.CertificateLookUpInformation.ValidationResult.ToString());
        //
        // if (!actual.ReferenceIdentifier.ValidationResult.IsValid)
        //     Assert.Fail(actual.ReferenceIdentifier.ValidationResult.ToString());
        //
        // if (!actual.SecurityTokenValue.ValidationResult.IsValid)
        //     Assert.Fail(actual.SecurityTokenValue.ValidationResult.ToString());

        Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iCj", true)]
	public void Validatation_RequiredCryptographicManagementPurposeCode(string cryptographicManagementPurposeCode, bool isValidExpected)
	{
		var subject = new CSC_CryptographicServiceMessageCertificatesAndKeys();
		subject.CryptographicManagementPurposeCode = cryptographicManagementPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
