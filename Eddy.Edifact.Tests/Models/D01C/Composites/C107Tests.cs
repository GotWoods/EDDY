using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C107Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "p:q:M";

		var expected = new C107_TextReference()
		{
			FreeTextDescriptionCode = "p",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "M",
		};

		var actual = Map.MapComposite<C107_TextReference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredFreeTextDescriptionCode(string freeTextDescriptionCode, bool isValidExpected)
	{
		var subject = new C107_TextReference();
		//Required fields
		//Test Parameters
		subject.FreeTextDescriptionCode = freeTextDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
