using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C770Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "0";

		var expected = new C770_ArrayCellDetails()
		{
			ArrayCellDataDescription = "0",
		};

		var actual = Map.MapComposite<C770_ArrayCellDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
