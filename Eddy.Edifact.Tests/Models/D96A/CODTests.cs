using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "COD++";

		var expected = new COD_ComponentDetails()
		{
			TypeOfUnitComponent = null,
			ComponentMaterial = null,
		};

		var actual = Map.MapObject<COD_ComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
