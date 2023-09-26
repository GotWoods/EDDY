using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SWDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWD*B*7*D*O*y*S*o*7*8";

		var expected = new SWD_SwitchingDetails()
		{
			InvoiceNumber = "B",
			Weight = 7,
			TariffApplicationCode = "D",
			ApplicationErrorConditionCode = "O",
			YesNoConditionOrResponseCode = "y",
			YesNoConditionOrResponseCode2 = "S",
			IndustryCode = "o",
			Number = 7,
			Number2 = 8,
		};

		var actual = Map.MapObject<SWD_SwitchingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
