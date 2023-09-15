using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E8*R*6J";

		var expected = new E8_BlockingAndResponseInformation()
		{
			BlockIdentification = "R",
			EmptyCarResponseCode = "6J",
		};

		var actual = Map.MapObject<E8_BlockingAndResponseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
