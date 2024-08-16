using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C951Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "O:e:a:n:q";

		var expected = new C951_Occupation()
		{
			OccupationDescriptionCode = "O",
			CodeListIdentificationCode = "e",
			CodeListResponsibleAgencyCode = "a",
			OccupationDescription = "n",
			OccupationDescription2 = "q",
		};

		var actual = Map.MapComposite<C951_Occupation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
