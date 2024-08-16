using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class BGMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BGM++v+R+k";

		var expected = new BGM_BeginningOfMessage()
		{
			DocumentMessageName = null,
			DocumentMessageNumber = "v",
			MessageFunctionCoded = "R",
			ResponseTypeCoded = "k",
		};

		var actual = Map.MapObject<BGM_BeginningOfMessage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
