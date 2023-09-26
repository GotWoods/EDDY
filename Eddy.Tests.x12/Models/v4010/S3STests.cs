using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S3STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3S*xxDKMK*Xq*x*i*u*2****n*lQlSsyT7JLLXkuTC";

		var expected = new S3S_SecurityHeaderLevel1()
		{
			SecurityVersionReleaseIdentifierCode = "xxDKMK",
			SecurityTypeCode = "Xq",
			SecurityOriginatorName = "x",
			SecurityRecipientName = "i",
			AuthenticationKeyName = "u",
			AuthenticationServiceCode = "2",
			CertificateLookUpInformation = null,
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "n",
			InitializationVector = "lQlSsyT7JLLXkuTC",
		};

		var actual = Map.MapObject<S3S_SecurityHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xxDKMK", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityTypeCode = "Xq";
		subject.SecurityOriginatorName = "x";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "u";
			subject.AuthenticationServiceCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xq", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "xxDKMK";
		subject.SecurityOriginatorName = "x";
		//Test Parameters
		subject.SecurityTypeCode = securityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "u";
			subject.AuthenticationServiceCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "xxDKMK";
		subject.SecurityTypeCode = "Xq";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "u";
			subject.AuthenticationServiceCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "2", true)]
	[InlineData("u", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "xxDKMK";
		subject.SecurityTypeCode = "Xq";
		subject.SecurityOriginatorName = "x";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
