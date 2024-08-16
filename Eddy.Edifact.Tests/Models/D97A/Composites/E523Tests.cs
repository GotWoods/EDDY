using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E523Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "8:R";

		var expected = new E523_NumberOfUnitDetails()
		{
			NumberOfUnits = "8",
			NumberOfUnitsQualifier = "R",
		};

		var actual = Map.MapComposite<E523_NumberOfUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
