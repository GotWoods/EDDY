using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CSMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSM*jXe*L*f";

		var expected = new CSM_CryptographicServiceMessageHeader()
		{
			CryptographicServiceMessageCSMMessageClassCode = "jXe",
			SecurityOriginatorName = "L",
			SecurityRecipientName = "f",
		};

		var actual = Map.MapObject<CSM_CryptographicServiceMessageHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jXe", true)]
	public void Validation_RequiredCryptographicServiceMessageCSMMessageClassCode(string cryptographicServiceMessageCSMMessageClassCode, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		//Required fields
		subject.SecurityOriginatorName = "L";
		subject.SecurityRecipientName = "f";
		//Test Parameters
		subject.CryptographicServiceMessageCSMMessageClassCode = cryptographicServiceMessageCSMMessageClassCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		//Required fields
		subject.CryptographicServiceMessageCSMMessageClassCode = "jXe";
		subject.SecurityRecipientName = "f";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredSecurityRecipientName(string securityRecipientName, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		//Required fields
		subject.CryptographicServiceMessageCSMMessageClassCode = "jXe";
		subject.SecurityOriginatorName = "L";
		//Test Parameters
		subject.SecurityRecipientName = securityRecipientName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
