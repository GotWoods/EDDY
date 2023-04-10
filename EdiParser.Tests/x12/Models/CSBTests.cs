using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CSBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSB*d4*A";

		var expected = new CSB_CryptographicServiceMessageBody()
		{
			CryptographicServiceMessageCSMFieldTagCode = "d4",
			CryptographicServiceMessageCSMFieldContents = "A",
		};

		var actual = Map.MapObject<CSB_CryptographicServiceMessageBody>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d4", true)]
	public void Validatation_RequiredCryptographicServiceMessageCSMFieldTagCode(string cryptographicServiceMessageCSMFieldTagCode, bool isValidExpected)
	{
		var subject = new CSB_CryptographicServiceMessageBody();
		subject.CryptographicServiceMessageCSMFieldTagCode = cryptographicServiceMessageCSMFieldTagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
