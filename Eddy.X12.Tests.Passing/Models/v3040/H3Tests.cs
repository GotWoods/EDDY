using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class H3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H3*Hg*di*3*u*Z";

		var expected = new H3_SpecialHandlingInstructions()
		{
			SpecialHandlingCode = "Hg",
			SpecialHandlingDescription = "di",
			ProtectiveServiceCode = "3",
			VentInstructionCode = "u",
			TariffApplicationCode = "Z",
		};

		var actual = Map.MapObject<H3_SpecialHandlingInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hg", "di", false)]
	[InlineData("Hg", "", true)]
	[InlineData("", "di", true)]
	public void Validation_OnlyOneOfSpecialHandlingCode(string specialHandlingCode, string specialHandlingDescription, bool isValidExpected)
	{
		var subject = new H3_SpecialHandlingInstructions();
		subject.SpecialHandlingCode = specialHandlingCode;
		subject.SpecialHandlingDescription = specialHandlingDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
