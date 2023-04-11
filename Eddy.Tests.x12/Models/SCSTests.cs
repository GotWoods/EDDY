using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCS*e*M";

		var expected = new SCS_CreditScore()
		{
			ReferenceIdentification = "e",
			FreeFormMessageText = "M",
		};

		var actual = Map.MapObject<SCS_CreditScore>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
