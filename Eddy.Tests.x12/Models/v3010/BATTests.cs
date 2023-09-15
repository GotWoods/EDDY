using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAT*xr9W7S*r3iW*Q*k5";

		var expected = new BAT_Batch()
		{
			Date = "xr9W7S",
			Time = "r3iW",
			ReferenceNumber = "Q",
			BatchTypeCode = "k5",
		};

		var actual = Map.MapObject<BAT_Batch>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
