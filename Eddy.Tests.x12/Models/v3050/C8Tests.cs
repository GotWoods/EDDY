using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class C8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C8*6*vt*A1*w";

		var expected = new C8_CertificationsAndClauses()
		{
			LadingLineItemNumber = 6,
			CertificationClauseCode = "vt",
			CertificationClauseText = "A1",
			ShippersExportDeclarationRequirements = "w",
		};

		var actual = Map.MapObject<C8_CertificationsAndClauses>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("A1", "vt", true)]
	[InlineData("A1", "", true)]
	[InlineData("", "vt", true)]
	public void Validation_AtLeastOneCertificationClauseText(string certificationClauseText, string certificationClauseCode, bool isValidExpected)
	{
		var subject = new C8_CertificationsAndClauses();
		subject.CertificationClauseText = certificationClauseText;
		subject.CertificationClauseCode = certificationClauseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
