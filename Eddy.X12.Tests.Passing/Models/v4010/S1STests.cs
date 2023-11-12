using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S1STests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1S*JR*p*l*T*R***3*yIF09Z3FUn96MSLq";

		var expected = new S1S_SecurityHeaderLevel1()
		{
			SecurityTypeCode = "JR",
			SecurityOriginatorName = "p",
			SecurityRecipientName = "l",
			AuthenticationKeyName = "T",
			AuthenticationServiceCode = "R",
			EncryptionKeyInformation = null,
			EncryptionServiceInformation = null,
			LengthOfData = "3",
			InitializationVector = "yIF09Z3FUn96MSLq",
		};

		var actual = Map.MapObject<S1S_SecurityHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JR", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityOriginatorName = "p";
		//Test Parameters
		subject.SecurityTypeCode = securityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "T";
			subject.AuthenticationServiceCode = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityTypeCode = "JR";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationKeyName) || !string.IsNullOrEmpty(subject.AuthenticationServiceCode))
		{
			subject.AuthenticationKeyName = "T";
			subject.AuthenticationServiceCode = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "R", true)]
	[InlineData("T", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredAuthenticationKeyName(string authenticationKeyName, string authenticationServiceCode, bool isValidExpected)
	{
		var subject = new S1S_SecurityHeaderLevel1();
		//Required fields
		subject.SecurityTypeCode = "JR";
		subject.SecurityOriginatorName = "p";
		//Test Parameters
		subject.AuthenticationKeyName = authenticationKeyName;
		subject.AuthenticationServiceCode = authenticationServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
