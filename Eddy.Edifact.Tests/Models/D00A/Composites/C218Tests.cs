using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C218Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:v:8:Z";

		var expected = new C218_HazardousMaterial()
		{
			HazardousMaterialCategoryNameCode = "k",
			CodeListIdentificationCode = "v",
			CodeListResponsibleAgencyCode = "8",
			HazardousMaterialCategoryName = "Z",
		};

		var actual = Map.MapComposite<C218_HazardousMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
