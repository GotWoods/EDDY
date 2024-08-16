using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C951Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:A:x:M:r";

		var expected = new C951_Occupation()
		{
			OccupationCoded = "G",
			CodeListQualifier = "A",
			CodeListResponsibleAgencyCoded = "x",
			Occupation = "M",
			Occupation2 = "r",
		};

		var actual = Map.MapComposite<C951_Occupation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
