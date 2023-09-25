using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSE*dGA5c9*L24lzm*HBX*3";

		var expected = new SSE_EntryAndExitInformation()
		{
			Date = "dGA5c9",
			Date2 = "L24lzm",
			StatusReasonCode = "HBX",
			Number = 3,
		};

		var actual = Map.MapObject<SSE_EntryAndExitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
