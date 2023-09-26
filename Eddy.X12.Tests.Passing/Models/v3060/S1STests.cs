using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class S1STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1S*jb*1*8*E*y***p*etgNuXA2oKOWkQc1";

		var expected = new S1S_SecurityHeaderLevel1()
		{
			SecurityType = "jb",
			SecurityOriginatorName = "1",
			SecurityRecipientName = "8",
			AuthenticationKeyName = "E",
			AuthenticationServiceCode = "y",
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "p",
			InitializationVector = "etgNuXA2oKOWkQc1",
		};

		var actual = Map.MapObject<S1S_SecurityHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jb", true)]
	public void Validation_RequiredSecurityType(string securityType, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityOriginatorName = "1";
		//Test Parameters
		subject.SecurityType = securityType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "E";
			subject.AuthenticationServiceCode = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityType = "jb";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "E";
			subject.AuthenticationServiceCode = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "y", true)]
	[InlineData("E", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityType = "jb";
		subject.SecurityOriginatorName = "1";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
