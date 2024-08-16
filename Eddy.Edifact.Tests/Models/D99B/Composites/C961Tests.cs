using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:E:t";

		var expected = new C961_FormulaComplexity()
		{
			FormulaComplexityCoded = "o",
			CodeListIdentificationCode = "E",
			CodeListResponsibleAgencyCode = "t",
		};

		var actual = Map.MapComposite<C961_FormulaComplexity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
