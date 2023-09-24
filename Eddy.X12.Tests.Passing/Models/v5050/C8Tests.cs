using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class C8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C8*9*oE*UP*0";

		var expected = new C8_CertificationsAndClauses()
		{
			LadingLineItemNumber = 9,
			CertificationClauseCode = "oE",
			CertificationClauseText = "UP",
			ShippersExportDeclarationRequirements = "0",
		};

		var actual = Map.MapObject<C8_CertificationsAndClauses>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("UP", "oE", true)]
	[InlineData("UP", "", true)]
	[InlineData("", "oE", true)]
	public void Validation_AtLeastOneCertificationClauseText(string certificationClauseText, string certificationClauseCode, bool isValidExpected)
	{
		var subject = new C8_CertificationsAndClauses();
		subject.CertificationClauseText = certificationClauseText;
		subject.CertificationClauseCode = certificationClauseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
