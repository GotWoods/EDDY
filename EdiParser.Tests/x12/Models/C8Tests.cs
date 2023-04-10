using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class C8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C8*1*RE*45*S";

		var expected = new C8_CertificationsAndClauses()
		{
			LadingLineItemNumber = 1,
			CertificationClauseCode = "RE",
			CertificationClauseText = "45",
			ShippersExportDeclarationRequirements = "S",
		};

		var actual = Map.MapObject<C8_CertificationsAndClauses>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("45","RE", true)]
	[InlineData("", "RE", true)]
	[InlineData("45", "", true)]
	public void Validation_AtLeastOneCertificationClauseText(string certificationClauseText, string certificationClauseCode, bool isValidExpected)
	{
		var subject = new C8_CertificationsAndClauses();
		subject.CertificationClauseText = certificationClauseText;
		subject.CertificationClauseCode = certificationClauseCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
