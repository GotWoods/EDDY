using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S2STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2S*wv*0wWd*FK0A*d*F*F*O*I*zBbC0uhOK64fXGkn";

		var expected = new S2S_SecurityHeaderLevel2()
		{
			SecurityType = "wv",
			SecurityOriginatorName = "0wWd",
			SecurityRecipientName = "FK0A",
			AuthenticationKeyName = "d",
			AuthenticationServiceCode = "F",
			EncryptionKeyName = "F",
			EncryptionServiceCode = "O",
			LengthOfDataLOD = "I",
			InitializationVectorIV = "zBbC0uhOK64fXGkn",
		};

		var actual = Map.MapObject<S2S_SecurityHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wv", true)]
	public void Validation_RequiredSecurityType(string securityType, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityOriginatorName = "0wWd";
		subject.SecurityRecipientName = "FK0A";
		//Test Parameters
		subject.SecurityType = securityType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "d";
			subject.AuthenticationServiceCode = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0wWd", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityType = "wv";
		subject.SecurityRecipientName = "FK0A";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "d";
			subject.AuthenticationServiceCode = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FK0A", true)]
	public void Validation_RequiredSecurityRecipientName(string securityRecipientName, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityType = "wv";
		subject.SecurityOriginatorName = "0wWd";
		//Test Parameters
		subject.SecurityRecipientName = securityRecipientName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "d";
			subject.AuthenticationServiceCode = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "F", true)]
	[InlineData("d", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityType = "wv";
		subject.SecurityOriginatorName = "0wWd";
		subject.SecurityRecipientName = "FK0A";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
