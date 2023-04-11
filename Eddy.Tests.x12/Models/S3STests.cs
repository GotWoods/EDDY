using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S3STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3S*vZbi5F*Bk*Q*t*q*1****H*Q";

		var expected = new S3S_SecurityHeaderLevel1()
		{
			SecurityVersionReleaseIdentifierCode = "vZbi5F",
			SecurityTypeCode = "Bk",
			SecurityOriginatorName = "Q",
			SecurityRecipientName = "t",
			AuthenticationKeyName = "q",
			AuthenticationServiceCode = "1",
			CertificateLookUpInformation = "",
			EncryptionKeyInformation = "",
			EncryptionServiceInformation = "",
			LengthOfData = "H",
			TransformedData = "Q",
		};

		var actual = Map.MapObject<S3S_SecurityHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vZbi5F", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		subject.SecurityTypeCode = "Bk";
		subject.SecurityOriginatorName = "Q";
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bk", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		subject.SecurityVersionReleaseIdentifierCode = "vZbi5F";
		subject.SecurityOriginatorName = "Q";
		subject.SecurityTypeCode = securityTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		subject.SecurityVersionReleaseIdentifierCode = "vZbi5F";
		subject.SecurityTypeCode = "Bk";
		subject.SecurityOriginatorName = securityOriginatorName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("q", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("q", "", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		subject.SecurityVersionReleaseIdentifierCode = "vZbi5F";
		subject.SecurityTypeCode = "Bk";
		subject.SecurityOriginatorName = "Q";
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
