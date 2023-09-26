using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class SPETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPE*D*A*AD*L";

		var expected = new SPE_SecurityProtocolError()
		{
			SecurityOriginatorName = "D",
			SecurityRecipientName = "A",
			SecurityTypeCode = "AD",
			SecurityOrAssuranceProtocolErrorCode = "L",
		};

		var actual = Map.MapObject<SPE_SecurityProtocolError>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		//Required fields
		subject.SecurityRecipientName = "A";
		subject.SecurityTypeCode = "AD";
		subject.SecurityOrAssuranceProtocolErrorCode = "L";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSecurityRecipientName(string securityRecipientName, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		//Required fields
		subject.SecurityOriginatorName = "D";
		subject.SecurityTypeCode = "AD";
		subject.SecurityOrAssuranceProtocolErrorCode = "L";
		//Test Parameters
		subject.SecurityRecipientName = securityRecipientName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AD", true)]
	public void Validation_RequiredSecurityTypeCode(string securityTypeCode, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		//Required fields
		subject.SecurityOriginatorName = "D";
		subject.SecurityRecipientName = "A";
		subject.SecurityOrAssuranceProtocolErrorCode = "L";
		//Test Parameters
		subject.SecurityTypeCode = securityTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredSecurityOrAssuranceProtocolErrorCode(string securityOrAssuranceProtocolErrorCode, bool isValidExpected)
	{
		var subject = new SPE_SecurityProtocolError();
		//Required fields
		subject.SecurityOriginatorName = "D";
		subject.SecurityRecipientName = "A";
		subject.SecurityTypeCode = "AD";
		//Test Parameters
		subject.SecurityOrAssuranceProtocolErrorCode = securityOrAssuranceProtocolErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
