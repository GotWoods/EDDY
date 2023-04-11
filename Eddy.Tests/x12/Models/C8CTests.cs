using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

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
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0U", true)]
	public void Validation_RequiredCertificationClauseText(string certificationClauseText, bool isValidExpected)
	{
		var subject = new C8C_CertificationsClausesContinuation();
		subject.CertificationClauseText = certificationClauseText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
