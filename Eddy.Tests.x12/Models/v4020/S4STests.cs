using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class S4STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4S*xS9eiO*TW*K*E*2*s****x*p";

		var expected = new S4S_SecurityHeaderLevel2()
		{
			SecurityVersionReleaseIdentifierCode = "xS9eiO",
			SecurityTypeCode = "TW",
			SecurityOriginatorName = "K",
			SecurityRecipientName = "E",
			AuthenticationKeyName = "2",
			AuthenticationServiceCode = "s",
			CertificateLookUpInformation = null,
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "x",
			TransformedData = "p",
		};

		var actual = Map.MapObject<S4S_SecurityHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xS9eiO", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityTypeCode = "TW";
		subject.SecurityOriginatorName = "K";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "2";
			subject.AuthenticationServiceCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TW", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "xS9eiO";
		subject.SecurityOriginatorName = "K";
		//Test Parameters
		subject.SecurityTypeCode = securityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "2";
			subject.AuthenticationServiceCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "xS9eiO";
		subject.SecurityTypeCode = "TW";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "2";
			subject.AuthenticationServiceCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "s", true)]
	[InlineData("2", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "xS9eiO";
		subject.SecurityTypeCode = "TW";
		subject.SecurityOriginatorName = "K";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
