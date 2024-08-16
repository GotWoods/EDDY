using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C770Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r";

		var expected = new C770_ArrayCellDetails()
		{
			ArrayCellInformation = "r",
		};

		var actual = Map.MapComposite<C770_ArrayCellDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
