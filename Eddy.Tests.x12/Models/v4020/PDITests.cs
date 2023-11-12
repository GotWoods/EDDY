using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDI*9*7*7*s";

		var expected = new PDI_PracticeDetailInformation()
		{
			GenderCode = "9",
			RangeMinimum = 7,
			RangeMaximum = 7,
			YesNoConditionOrResponseCode = "s",
		};

		var actual = Map.MapObject<PDI_PracticeDetailInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
