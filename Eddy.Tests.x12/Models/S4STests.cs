using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S4STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4S*my9EYR*o0*H*b*n*9****h*t";

		var expected = new S4S_SecurityHeaderLevel2()
		{
			SecurityVersionReleaseIdentifierCode = "my9EYR",
			SecurityTypeCode = "o0",
			SecurityOriginatorName = "H",
			SecurityRecipientName = "b",
			AuthenticationKeyName = "n",
			AuthenticationServiceCode = "9",
			CertificateLookUpInformation = "",
			EncryptionKeyInformation = "",
			EncryptionServiceInformation = "",
			LengthOfData = "h",
			TransformedData = "t",
		};

		var actual = Map.MapObject<S4S_SecurityHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("my9EYR", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		subject.SecurityTypeCode = "o0";
		subject.SecurityOriginatorName = "H";
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o0", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		subject.SecurityVersionReleaseIdentifierCode = "my9EYR";
		subject.SecurityOriginatorName = "H";
		subject.SecurityTypeCode = securityTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		subject.SecurityVersionReleaseIdentifierCode = "my9EYR";
		subject.SecurityTypeCode = "o0";
		subject.SecurityOriginatorName = securityOriginatorName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("n", "9", true)]
	[InlineData("", "9", false)]
	[InlineData("n", "", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S4S_SecurityHeaderLevel2();
		subject.SecurityVersionReleaseIdentifierCode = "my9EYR";
		subject.SecurityTypeCode = "o0";
		subject.SecurityOriginatorName = "H";
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
