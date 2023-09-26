using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class C8CTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C8C*jV*wJ*Wa";

		var expected = new C8C_CertificationsClausesContinuation()
		{
			CertificationClauseText = "jV",
			CertificationClauseText2 = "wJ",
			CertificationClauseText3 = "Wa",
		};

		var actual = Map.MapObject<C8C_CertificationsClausesContinuation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jV", true)]
	public void Validation_RequiredCertificationClauseText(string certificationClauseText, bool isValidExpected)
	{
		var subject = new C8C_CertificationsClausesContinuation();
		//Required fields
		//Test Parameters
		subject.CertificationClauseText = certificationClauseText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
