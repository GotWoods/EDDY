using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSE*j2NsP3k9*zpxaSdYw*6sZ*5";

		var expected = new SSE_EntryAndExitInformation()
		{
			Date = "j2NsP3k9",
			Date2 = "zpxaSdYw",
			StatusReasonCode = "6sZ",
			Number = 5,
		};

		var actual = Map.MapObject<SSE_EntryAndExitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
