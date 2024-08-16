using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C218Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:Z:c:z";

		var expected = new C218_HazardousMaterial()
		{
			HazardousMaterialCategoryNameCode = "r",
			CodeListIdentificationCode = "Z",
			CodeListResponsibleAgencyCode = "c",
			HazardousMaterialCategoryName = "z",
		};

		var actual = Map.MapComposite<C218_HazardousMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
