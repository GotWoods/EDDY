using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CSMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSM*bn7*a*4";

		var expected = new CSM_CryptographicServiceMessageHeader()
		{
			CryptographicServiceMessageCSMMessageClassCode = "bn7",
			SecurityOriginatorName = "a",
			SecurityRecipientName = "4",
		};

		var actual = Map.MapObject<CSM_CryptographicServiceMessageHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bn7", true)]
	public void Validatation_RequiredCryptographicServiceMessageCSMMessageClassCode(string cryptographicServiceMessageCSMMessageClassCode, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		subject.CryptographicServiceMessageCSMMessageClassCode = cryptographicServiceMessageCSMMessageClassCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
