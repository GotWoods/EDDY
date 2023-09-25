using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CSBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSB*HG*O";

		var expected = new CSB_CryptographicServiceMessageBody()
		{
			CryptographicServiceMessageCSMFieldTag = "HG",
			CryptographicServiceMessageCSMFieldContents = "O",
		};

		var actual = Map.MapObject<CSB_CryptographicServiceMessageBody>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HG", true)]
	public void Validation_RequiredCryptographicServiceMessageCSMFieldTag(string cryptographicServiceMessageCSMFieldTag, bool isValidExpected)
	{
		var subject = new CSB_CryptographicServiceMessageBody();
		//Required fields
		//Test Parameters
		subject.CryptographicServiceMessageCSMFieldTag = cryptographicServiceMessageCSMFieldTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
