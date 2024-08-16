using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class BGMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BGM+++Q+7";

		var expected = new BGM_BeginningOfMessage()
		{
			DocumentMessageName = null,
			DocumentMessageIdentification = null,
			MessageFunctionCoded = "Q",
			ResponseTypeCoded = "7",
		};

		var actual = Map.MapObject<BGM_BeginningOfMessage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
