using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class C8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C8*6*MV*3h";

		var expected = new C8_CertificationsAndClauses()
		{
			LadingLineItemNumber = 6,
			CertificationClauseCode = "MV",
			CertificationClauseText = "3h",
		};

		var actual = Map.MapObject<C8_CertificationsAndClauses>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredLadingLineItemNumber(int ladingLineItemNumber, bool isValidExpected)
	{
		var subject = new C8_CertificationsAndClauses();
		if (ladingLineItemNumber > 0)
			subject.LadingLineItemNumber = ladingLineItemNumber;
			subject.CertificationClauseText = "3h";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("3h", "MV", true)]
	[InlineData("3h", "", true)]
	[InlineData("", "MV", true)]
	public void Validation_AtLeastOneCertificationClauseText(string certificationClauseText, string certificationClauseCode, bool isValidExpected)
	{
		var subject = new C8_CertificationsAndClauses();
		subject.LadingLineItemNumber = 6;
		subject.CertificationClauseText = certificationClauseText;
		subject.CertificationClauseCode = certificationClauseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
