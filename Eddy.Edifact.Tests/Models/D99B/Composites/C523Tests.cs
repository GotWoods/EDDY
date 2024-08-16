using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C523Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:x";

		var expected = new C523_NumberOfUnitDetails()
		{
			NumberOfUnits = "7",
			UnitTypeCodeQualifier = "x",
		};

		var actual = Map.MapComposite<C523_NumberOfUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
