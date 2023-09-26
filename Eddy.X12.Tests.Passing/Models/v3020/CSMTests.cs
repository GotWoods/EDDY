using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CSMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSM*T8e*wIN6*8rBs";

		var expected = new CSM_CryptographicServiceMessageHeader()
		{
			CryptographicServiceMessageCSMMessageClassCode = "T8e",
			SecurityOriginatorName = "wIN6",
			SecurityRecipientName = "8rBs",
		};

		var actual = Map.MapObject<CSM_CryptographicServiceMessageHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T8e", true)]
	public void Validation_RequiredCryptographicServiceMessageCSMMessageClassCode(string cryptographicServiceMessageCSMMessageClassCode, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		//Required fields
		subject.SecurityOriginatorName = "wIN6";
		subject.SecurityRecipientName = "8rBs";
		//Test Parameters
		subject.CryptographicServiceMessageCSMMessageClassCode = cryptographicServiceMessageCSMMessageClassCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wIN6", true)]
	public void Validation_RequiredSecurityOriginatorName(string securityOriginatorName, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		//Required fields
		subject.CryptographicServiceMessageCSMMessageClassCode = "T8e";
		subject.SecurityRecipientName = "8rBs";
		//Test Parameters
		subject.SecurityOriginatorName = securityOriginatorName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8rBs", true)]
	public void Validation_RequiredSecurityRecipientName(string securityRecipientName, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		//Required fields
		subject.CryptographicServiceMessageCSMMessageClassCode = "T8e";
		subject.SecurityOriginatorName = "wIN6";
		//Test Parameters
		subject.SecurityRecipientName = securityRecipientName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
