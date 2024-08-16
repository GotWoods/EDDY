using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C107Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "F:8:R";

		var expected = new C107_TextReference()
		{
			FreeTextValueCode = "F",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "R",
		};

		var actual = Map.MapComposite<C107_TextReference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredFreeTextValueCode(string freeTextValueCode, bool isValidExpected)
	{
		var subject = new C107_TextReference();
		//Required fields
		//Test Parameters
		subject.FreeTextValueCode = freeTextValueCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
