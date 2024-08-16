using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:E:B";

		var expected = new C961_FormulaComplexity()
		{
			FormulaComplexityCode = "5",
			CodeListIdentificationCode = "E",
			CodeListResponsibleAgencyCode = "B",
		};

		var actual = Map.MapComposite<C961_FormulaComplexity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
