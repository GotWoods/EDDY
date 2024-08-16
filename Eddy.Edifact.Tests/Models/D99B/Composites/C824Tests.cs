using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C824Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:R:F:X";

		var expected = new C824_ComponentMaterial()
		{
			ComponentMaterialCoded = "Z",
			CodeListIdentificationCode = "R",
			CodeListResponsibleAgencyCode = "F",
			ComponentMaterial = "X",
		};

		var actual = Map.MapComposite<C824_ComponentMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
