using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDI*W*1*9*2";

		var expected = new PDI_PracticeDetailInformation()
		{
			GenderCode = "W",
			RangeMinimum = 1,
			RangeMaximum = 9,
			YesNoConditionOrResponseCode = "2",
		};

		var actual = Map.MapObject<PDI_PracticeDetailInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
