using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C972Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "g:G:s:x";

		var expected = new C972_ProvisoCalculation()
		{
			ProvisoCalculationDescriptionCode = "g",
			CodeListIdentificationCode = "G",
			CodeListResponsibleAgencyCode = "s",
			ProvisoCalculationDescription = "x",
		};

		var actual = Map.MapComposite<C972_ProvisoCalculation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
