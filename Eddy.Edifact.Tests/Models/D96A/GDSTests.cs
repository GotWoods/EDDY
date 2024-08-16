using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class GDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GDS+";

		var expected = new GDS_NatureOfCargo()
		{
			NatureOfCargo = null,
		};

		var actual = Map.MapObject<GDS_NatureOfCargo>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
