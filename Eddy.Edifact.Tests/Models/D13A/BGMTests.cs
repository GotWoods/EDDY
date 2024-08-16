using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D13A;
using Eddy.Edifact.Models.D13A.Composites;

namespace Eddy.Edifact.Tests.Models.D13A;

public class BGMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BGM+++s+t+N";

		var expected = new BGM_BeginningOfMessage()
		{
			DocumentMessageName = null,
			DocumentMessageIdentification = null,
			MessageFunctionCode = "s",
			ResponseTypeCode = "t",
			DocumentStatusCode = "N",
		};

		var actual = Map.MapObject<BGM_BeginningOfMessage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
