using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSC*O33*i*a***B2L*8*X*";

		var expected = new CSC_CryptographicServiceMessageCertificatesAndKeys()
		{
			CryptographicManagementPurpose = "O33",
			SecurityOriginatorName = "i",
			SecurityRecipientName = "a",
			CertificateLookUpInformation = null,
			ReferenceIdentifier = null,
			FilterIDCode = "B2L",
			VersionIdentifier = "8",
			LengthOfData = "X",
			SecurityTokenValue = null,
		};

		var actual = Map.MapObject<CSC_CryptographicServiceMessageCertificatesAndKeys>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O33", true)]
	public void Validation_RequiredCryptographicManagementPurpose(string cryptographicManagementPurpose, bool isValidExpected)
	{
		var subject = new CSC_CryptographicServiceMessageCertificatesAndKeys();
		//Required fields
		//Test Parameters
		subject.CryptographicManagementPurpose = cryptographicManagementPurpose;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
