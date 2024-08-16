using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01B;
using Eddy.Edifact.Models.D01B.Composites;

namespace Eddy.Edifact.Tests.Models.D01B.Composites;

public class C218Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:P:L:S";

		var expected = new C218_HazardousMaterial()
		{
			HazardousMaterialCategoryNameCode = "4",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "L",
			HazardousMaterialCategoryName = "S",
		};

		var actual = Map.MapComposite<C218_HazardousMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
