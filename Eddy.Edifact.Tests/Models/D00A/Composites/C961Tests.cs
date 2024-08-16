using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "1:s:5";

		var expected = new C961_FormulaComplexity()
		{
			FormulaComplexityCode = "1",
			CodeListIdentificationCode = "s",
			CodeListResponsibleAgencyCode = "5",
		};

		var actual = Map.MapComposite<C961_FormulaComplexity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
