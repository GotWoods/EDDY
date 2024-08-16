using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D13B;
using Eddy.Edifact.Models.D13B.Composites;

namespace Eddy.Edifact.Tests.Models.D13B;

public class BGMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BGM+++D+0+9+r";

		var expected = new BGM_BeginningOfMessage()
		{
			DocumentMessageName = null,
			DocumentMessageIdentification = null,
			MessageFunctionCode = "D",
			ResponseTypeCode = "0",
			DocumentStatusCode = "9",
			LanguageNameCode = "r",
		};

		var actual = Map.MapObject<BGM_BeginningOfMessage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
