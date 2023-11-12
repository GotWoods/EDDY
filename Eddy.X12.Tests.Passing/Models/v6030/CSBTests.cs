using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CSBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSB*wJ*t";

		var expected = new CSB_CryptographicServiceMessageBody()
		{
			CryptographicServiceMessageCSMFieldTagCode = "wJ",
			CryptographicServiceMessageCSMFieldContents = "t",
		};

		var actual = Map.MapObject<CSB_CryptographicServiceMessageBody>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wJ", true)]
	public void Validation_RequiredCryptographicServiceMessageCSMFieldTagCode(string cryptographicServiceMessageCSMFieldTagCode, bool isValidExpected)
	{
		var subject = new CSB_CryptographicServiceMessageBody();
		//Required fields
		//Test Parameters
		subject.CryptographicServiceMessageCSMFieldTagCode = cryptographicServiceMessageCSMFieldTagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
