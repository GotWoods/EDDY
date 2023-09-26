using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CSMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSM*tyl*w*p";

		var expected = new CSM_CryptographicServiceMessageHeader()
		{
			CryptographicServiceMessageCSMMessageClassCode = "tyl",
			SecurityOriginatorName = "w",
			SecurityRecipientName = "p",
		};

		var actual = Map.MapObject<CSM_CryptographicServiceMessageHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tyl", true)]
	public void Validation_RequiredCryptographicServiceMessageCSMMessageClassCode(string cryptographicServiceMessageCSMMessageClassCode, bool isValidExpected)
	{
		var subject = new CSM_CryptographicServiceMessageHeader();
		//Required fields
		//Test Parameters
		subject.CryptographicServiceMessageCSMMessageClassCode = cryptographicServiceMessageCSMMessageClassCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
