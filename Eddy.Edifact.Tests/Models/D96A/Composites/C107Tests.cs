using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C107Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:L:5";

		var expected = new C107_TextReference()
		{
			FreeTextCoded = "U",
			CodeListQualifier = "L",
			CodeListResponsibleAgencyCoded = "5",
		};

		var actual = Map.MapComposite<C107_TextReference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredFreeTextCoded(string freeTextCoded, bool isValidExpected)
	{
		var subject = new C107_TextReference();
		//Required fields
		//Test Parameters
		subject.FreeTextCoded = freeTextCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
