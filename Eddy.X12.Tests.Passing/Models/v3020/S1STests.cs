using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S1STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1S*tH*f8et*97oy*i*J*u*S*x*jnzqATryjXRD5RpX";

		var expected = new S1S_SecurityHeaderLevel1()
		{
			SecurityType = "tH",
			SecurityOriginatorName = "f8et",
			SecurityRecipientName = "97oy",
			AuthenticationKeyName = "i",
			AuthenticationServiceCode = "J",
			EncryptionKeyName = "u",
			EncryptionServiceCode = "S",
			LengthOfDataLOD = "x",
			InitializationVectorIV = "jnzqATryjXRD5RpX",
		};

		var actual = Map.MapObject<S1S_SecurityHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tH", true)]
	public void Validation_RequiredSecurityType(string securityType, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityOriginatorName = "f8et";
		subject.SecurityRecipientName = "97oy";
		//Test Parameters
		subject.SecurityType = securityType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "i";
			subject.AuthenticationServiceCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f8et", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityType = "tH";
		subject.SecurityRecipientName = "97oy";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "i";
			subject.AuthenticationServiceCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("97oy", true)]
	public void Validation_RequiredSecurityRecipientName(string securityRecipientName, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityType = "tH";
		subject.SecurityOriginatorName = "f8et";
		//Test Parameters
		subject.SecurityRecipientName = securityRecipientName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "i";
			subject.AuthenticationServiceCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "J", true)]
	[InlineData("i", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityType = "tH";
		subject.SecurityOriginatorName = "f8et";
		subject.SecurityRecipientName = "97oy";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
