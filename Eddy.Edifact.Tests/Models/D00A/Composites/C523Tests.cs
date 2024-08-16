using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C523Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:0";

		var expected = new C523_NumberOfUnitDetails()
		{
			UnitsQuantity = "A",
			UnitTypeCodeQualifier = "0",
		};

		var actual = Map.MapComposite<C523_NumberOfUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
