using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSC*YJB*3*W***BeJ*h*c*";

		var expected = new CSC_CryptographicServiceMessageCertificatesAndKeys()
		{
			CryptographicManagementPurpose = "YJB",
			SecurityOriginatorName = "3",
			SecurityRecipientName = "W",
			CertificateLookUpInformation = null,
			ReferenceIdentifier = null,
			FilterIDCode = "BeJ",
			VersionIdentifier = "h",
			LengthOfData = "c",
			SecurityValue = null,
		};

		var actual = Map.MapObject<CSC_CryptographicServiceMessageCertificatesAndKeys>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YJB", true)]
	public void Validation_RequiredCryptographicManagementPurpose(string cryptographicManagementPurpose, bool isValidExpected)
	{
		var subject = new CSC_CryptographicServiceMessageCertificatesAndKeys();
		//Required fields
		//Test Parameters
		subject.CryptographicManagementPurpose = cryptographicManagementPurpose;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
