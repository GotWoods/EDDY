using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class H3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H3*f4*Ft*N*v*Y";

		var expected = new H3_SpecialHandlingInstructions()
		{
			SpecialHandlingCode = "f4",
			SpecialHandlingDescription = "Ft",
			ProtectiveServiceCode = "N",
			VentInstructionCode = "v",
			TariffApplicationCode = "Y",
		};

		var actual = Map.MapObject<H3_SpecialHandlingInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f4", "Ft", false)]
	[InlineData("f4", "", true)]
	[InlineData("", "Ft", true)]
	public void Validation_OnlyOneOfSpecialHandlingCode(string specialHandlingCode, string specialHandlingDescription, bool isValidExpected)
	{
		var subject = new H3_SpecialHandlingInstructions();
		subject.SpecialHandlingCode = specialHandlingCode;
		subject.SpecialHandlingDescription = specialHandlingDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
