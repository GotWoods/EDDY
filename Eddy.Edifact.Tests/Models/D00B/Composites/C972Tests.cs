using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C972Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:7:b:b";

		var expected = new C972_ProvisoCalculation()
		{
			ProvisoCalculationDescriptionCode = "q",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "b",
			ProvisoCalculationDescription = "b",
		};

		var actual = Map.MapComposite<C972_ProvisoCalculation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
