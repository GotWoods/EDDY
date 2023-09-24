using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L11*r*2I*W";

		var expected = new L11_BusinessInstructions()
		{
			ReferenceNumber = "r",
			ReferenceNumberQualifier = "2I",
			Description = "W",
		};

		var actual = Map.MapObject<L11_BusinessInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
