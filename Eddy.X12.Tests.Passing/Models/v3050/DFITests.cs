using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DFI*LMC*i*X*8";

		var expected = new DFI_DefaultInformation()
		{
			StatusReasonCode = "LMC",
			ClaimFilingIndicatorCode = "i",
			YesNoConditionOrResponseCode = "X",
			YesNoConditionOrResponseCode2 = "8",
		};

		var actual = Map.MapObject<DFI_DefaultInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
