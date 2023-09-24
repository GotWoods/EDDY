using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SWDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SWD*x*5*n*n*8*a*Q*7*8";

		var expected = new SWD_SwitchingDetails()
		{
			InvoiceNumber = "x",
			Weight = 5,
			TariffApplicationCode = "n",
			ApplicationErrorConditionCode = "n",
			YesNoConditionOrResponseCode = "8",
			YesNoConditionOrResponseCode2 = "a",
			IndustryCode = "Q",
			Number = 7,
			Number2 = 8,
		};

		var actual = Map.MapObject<SWD_SwitchingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
