using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S2STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2S*Wm*3*A*t*J***I*Q2SHeEO7N6BsJeXc";

		var expected = new S2S_SecurityHeaderLevel2()
		{
			SecurityTypeCode = "Wm",
			SecurityOriginatorName = "3",
			SecurityRecipientName = "A",
			AuthenticationKeyName = "t",
			AuthenticationServiceCode = "J",
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "I",
			InitializationVector = "Q2SHeEO7N6BsJeXc",
		};

		var actual = Map.MapObject<S2S_SecurityHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wm", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityOriginatorName = "3";
		//Test Parameters
		subject.SecurityTypeCode = securityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "t";
			subject.AuthenticationServiceCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityTypeCode = "Wm";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "t";
			subject.AuthenticationServiceCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "J", true)]
	[InlineData("t", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S2S_SecurityHeaderLevel2();
		//Required fields
		subject.SecurityTypeCode = "Wm";
		subject.SecurityOriginatorName = "3";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
