using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class S3STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3S*0h6kWN*th*c*x*i*z****M*S";

		var expected = new S3S_SecurityHeaderLevel1()
		{
			SecurityVersionReleaseIdentifierCode = "0h6kWN",
			SecurityTypeCode = "th",
			SecurityOriginatorName = "c",
			SecurityRecipientName = "x",
			AuthenticationKeyName = "i",
			AuthenticationServiceCode = "z",
			CertificateLookUpInformation = null,
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "M",
			TransformedData = "S",
		};

		var actual = Map.MapObject<S3S_SecurityHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0h6kWN", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityTypeCode = "th";
		subject.SecurityOriginatorName = "c";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "i";
			subject.AuthenticationServiceCode = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("th", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "0h6kWN";
		subject.SecurityOriginatorName = "c";
		//Test Parameters
		subject.SecurityTypeCode = securityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "i";
			subject.AuthenticationServiceCode = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "0h6kWN";
		subject.SecurityTypeCode = "th";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "i";
			subject.AuthenticationServiceCode = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "z", true)]
	[InlineData("i", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S3S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "0h6kWN";
		subject.SecurityTypeCode = "th";
		subject.SecurityOriginatorName = "c";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
