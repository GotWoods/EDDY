using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPE*E*u*h8*d";

		var expected = new SPE_SecurityProtocolError()
		{
			SecurityOriginatorName = "E",
			SecurityRecipientName = "u",
			SecurityTypeCode = "h8",
			SecurityOrAssuranceProtocolErrorCode = "d",
		};

		var actual = Map.MapObject<SPE_SecurityProtocolError>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		subject.SecurityRecipientName = "u";
		subject.SecurityTypeCode = "h8";
		subject.SecurityOrAssuranceProtocolErrorCode = "d";
		subject.SecurityOriginatorName = securityOriginatorName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredSecurityRecipientName(string securityRecipientName, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		subject.SecurityOriginatorName = "E";
		subject.SecurityTypeCode = "h8";
		subject.SecurityOrAssuranceProtocolErrorCode = "d";
		subject.SecurityRecipientName = securityRecipientName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h8", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		subject.SecurityOriginatorName = "E";
		subject.SecurityRecipientName = "u";
		subject.SecurityOrAssuranceProtocolErrorCode = "d";
		subject.SecurityTypeCode = securityTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredSecurityOrAssuranceProtocolErrorCode(string securityOrAssuranceProtocolErrorCode, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		subject.SecurityOriginatorName = "E";
		subject.SecurityRecipientName = "u";
		subject.SecurityTypeCode = "h8";
		subject.SecurityOrAssuranceProtocolErrorCode = securityOrAssuranceProtocolErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
