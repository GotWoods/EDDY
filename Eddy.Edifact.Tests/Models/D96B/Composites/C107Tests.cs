using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C107Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:3:k";

		var expected = new C107_TextReference()
		{
			FreeTextIdentification = "S",
			CodeListQualifier = "3",
			CodeListResponsibleAgencyCoded = "k",
		};

		var actual = Map.MapComposite<C107_TextReference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredFreeTextIdentification(string freeTextIdentification, bool isValidExpected)
	{
		var subject = new C107_TextReference();
		//Required fields
		//Test Parameters
		subject.FreeTextIdentification = freeTextIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
