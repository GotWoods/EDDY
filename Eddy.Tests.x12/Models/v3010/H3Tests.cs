using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class H3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H3*mr*Xt*O*m*F";

		var expected = new H3_SpecialHandlingInstructions()
		{
			SpecialHandlingCode = "mr",
			SpecialHandlingDescription = "Xt",
			ProtectiveServiceCode = "O",
			VentInstructionCode = "m",
			TariffApplicationCode = "F",
		};

		var actual = Map.MapObject<H3_SpecialHandlingInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
