using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSE*b6NOLvmq*umbBBia2*N6U*9*HAL";

		var expected = new SSE_EntryAndExitInformation()
		{
			Date = "b6NOLvmq",
			Date2 = "umbBBia2",
			StatusReasonCode = "N6U",
			Number = 9,
			StatusReasonCode2 = "HAL",
		};

		var actual = Map.MapObject<SSE_EntryAndExitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
