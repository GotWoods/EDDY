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
		string x12Line = "CSC*iCj*1*S***hfx*G*m*";

		var expected = new CSC_CryptographicServiceMessageCertificatesAndKeys()
		{
			CryptographicManagementPurposeCode = "iCj",
			SecurityOriginatorName = "1",
			SecurityRecipientName = "S",
			CertificateLookUpInformation = new C050_CertificateLookUpInformation(),
			ReferenceIdentifier = new C040_ReferenceIdentifier(),
			FilterIDCode = "hfx",
			VersionIdentifier = "G",
			LengthOfData = "m",
			SecurityTokenValue = new C033_SecurityTokenValue(),
		};

		var actual = Map.MapObject<CSC_CryptographicServiceMessageCertificatesAndKeys>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
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
