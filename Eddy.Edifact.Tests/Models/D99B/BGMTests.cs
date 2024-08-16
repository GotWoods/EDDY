using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class BGMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BGM+++t+h";

		var expected = new BGM_BeginningOfMessage()
		{
			DocumentMessageName = null,
			DocumentMessageIdentification = null,
			MessageFunctionCode = "t",
			ResponseTypeCode = "h",
		};

		var actual = Map.MapObject<BGM_BeginningOfMessage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
