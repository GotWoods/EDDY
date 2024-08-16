using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C951Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "1:g:r:B:x";

		var expected = new C951_Occupation()
		{
			OccupationCoded = "1",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "r",
			Occupation = "B",
			Occupation2 = "x",
		};

		var actual = Map.MapComposite<C951_Occupation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
