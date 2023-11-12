using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSC*hq1*5*O***4pj*X*P*";

		var expected = new CSC_CryptographicServiceMessageCertificatesAndKeys()
		{
			CryptographicManagementPurposeCode = "hq1",
			SecurityOriginatorName = "5",
			SecurityRecipientName = "O",
			CertificateLookUpInformation = null,
			ReferenceIdentifier = null,
			FilterIDCode = "4pj",
			VersionIdentifier = "X",
			LengthOfData = "P",
			SecurityTokenValue = null,
		};

		var actual = Map.MapObject<CSC_CryptographicServiceMessageCertificatesAndKeys>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hq1", true)]
	public void Validation_RequiredCryptographicManagementPurposeCode(string cryptographicManagementPurposeCode, bool isValidExpected)
	{
		var subject = new CSC_CryptographicServiceMessageCertificatesAndKeys();
		//Required fields
		//Test Parameters
		subject.CryptographicManagementPurposeCode = cryptographicManagementPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
