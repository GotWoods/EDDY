using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C107Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:8:8";

		var expected = new C107_TextReference()
		{
			FreeTextValueCode = "x",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "8",
		};

		var actual = Map.MapComposite<C107_TextReference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredFreeTextValueCode(string freeTextValueCode, bool isValidExpected)
	{
		var subject = new C107_TextReference();
		//Required fields
		//Test Parameters
		subject.FreeTextValueCode = freeTextValueCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
