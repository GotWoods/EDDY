using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSD*o*P";

		var expected = new TSD_TrailerShipmentDetails()
		{
			AssignedIdentification = "o",
			Position = "P",
		};

		var actual = Map.MapObject<TSD_TrailerShipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
