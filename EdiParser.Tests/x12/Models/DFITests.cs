using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DFI*Maw*d*h*o";

		var expected = new DFI_DefaultInformation()
		{
			StatusReasonCode = "Maw",
			ClaimFilingIndicatorCode = "d",
			YesNoConditionOrResponseCode = "h",
			YesNoConditionOrResponseCode2 = "o",
		};

		var actual = Map.MapObject<DFI_DefaultInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
