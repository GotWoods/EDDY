using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C951Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:w:9:C:9";

		var expected = new C951_Occupation()
		{
			OccupationDescriptionCode = "U",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "9",
			OccupationDescription = "C",
			OccupationDescription2 = "9",
		};

		var actual = Map.MapComposite<C951_Occupation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
