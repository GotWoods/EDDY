using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class S2STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2S*wK*n*z*O*Y***n*JC8bYGrakvgqWBBp";

		var expected = new S2S_SecurityHeaderLevel2()
		{
			SecurityType = "wK",
			SecurityOriginatorName = "n",
			SecurityRecipientName = "z",
			AuthenticationKeyName = "O",
			AuthenticationServiceCode = "Y",
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "n",
			InitializationVector = "JC8bYGrakvgqWBBp",
		};

		var actual = Map.MapObject<S2S_SecurityHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wK", true)]
	public void Validation_RequiredSecurityType(string securityType, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityOriginatorName = "n";
		//Test Parameters
		subject.SecurityType = securityType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "O";
			subject.AuthenticationServiceCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityType = "wK";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "O";
			subject.AuthenticationServiceCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "Y", true)]
	[InlineData("O", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityType = "wK";
		subject.SecurityOriginatorName = "n";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
