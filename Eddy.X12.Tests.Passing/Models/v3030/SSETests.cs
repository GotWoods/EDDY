using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SSETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSE*bbwHvK*QMjBSO*168";

		var expected = new SSE_EntryAndExitDates()
		{
			Date = "bbwHvK",
			Date2 = "QMjBSO",
			StatusReasonCode = "168",
		};

		var actual = Map.MapObject<SSE_EntryAndExitDates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
