using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class SSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSE*0UJWGnnw*72tR5Pkv*spU*9*kEH";

		var expected = new SSE_EntryAndExitInformation()
		{
			Date = "0UJWGnnw",
			Date2 = "72tR5Pkv",
			StatusReasonCode = "spU",
			Number = 9,
			StatusReasonCode2 = "kEH",
		};

		var actual = Map.MapObject<SSE_EntryAndExitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
