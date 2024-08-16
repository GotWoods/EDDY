using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E523Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Z:S";

		var expected = new E523_NumberOfUnitDetails()
		{
			NumberOfUnits = "Z",
			UnitTypeCodeQualifier = "S",
		};

		var actual = Map.MapComposite<E523_NumberOfUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
