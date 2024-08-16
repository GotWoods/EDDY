using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class C961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "G:7:i";

		var expected = new C961_FormulaComplexity()
		{
			FormulaComplexityCoded = "G",
			CodeListQualifier = "7",
			CodeListResponsibleAgencyCoded = "i",
		};

		var actual = Map.MapComposite<C961_FormulaComplexity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
