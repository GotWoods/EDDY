using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S4STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4S*8HSjvB*H7*B*m*9*s****N*oKQyLEiz1KjVxkKK";

		var expected = new S4S_SecurityHeaderLevel2()
		{
			SecurityVersionReleaseIdentifierCode = "8HSjvB",
			SecurityTypeCode = "H7",
			SecurityOriginatorName = "B",
			SecurityRecipientName = "m",
			AuthenticationKeyName = "9",
			AuthenticationServiceCode = "s",
			CertificateLookUpInformation = null,
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "N",
			InitializationVector = "oKQyLEiz1KjVxkKK",
		};

		var actual = Map.MapObject<S4S_SecurityHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8HSjvB", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityTypeCode = "H7";
		subject.SecurityOriginatorName = "B";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "9";
			subject.AuthenticationServiceCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H7", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "8HSjvB";
		subject.SecurityOriginatorName = "B";
		//Test Parameters
		subject.SecurityTypeCode = securityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "9";
			subject.AuthenticationServiceCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "8HSjvB";
		subject.SecurityTypeCode = "H7";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "9";
			subject.AuthenticationServiceCode = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "s", true)]
	[InlineData("9", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "8HSjvB";
		subject.SecurityTypeCode = "H7";
		subject.SecurityOriginatorName = "B";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
