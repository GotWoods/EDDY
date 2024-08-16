using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C523Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:w";

		var expected = new C523_NumberOfUnitDetails()
		{
			NumberOfUnits = "v",
			NumberOfUnitsQualifier = "w",
		};

		var actual = Map.MapComposite<C523_NumberOfUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
