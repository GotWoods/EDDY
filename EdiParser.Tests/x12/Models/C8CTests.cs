using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class C8CTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C8C*0U*Q8*8R";

		var expected = new C8C_CertificationsClausesContinuation()
		{
			CertificationClauseText = "0U",
			CertificationClauseText2 = "Q8",
			CertificationClauseText3 = "8R",
		};

		var actual = Map.MapObject<C8C_CertificationsClausesContinuation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("0U", true)]
	public void Validatation_RequiredCertificationClauseText(string certificationClauseText, bool isValidExpected)
	{
		var subject = new C8C_CertificationsClausesContinuation();
		subject.CertificationClauseText = certificationClauseText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
