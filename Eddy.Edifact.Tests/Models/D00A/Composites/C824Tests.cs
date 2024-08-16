using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C824Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:I:B:u";

		var expected = new C824_ComponentMaterial()
		{
			ComponentMaterialDescriptionCode = "t",
			CodeListIdentificationCode = "I",
			CodeListResponsibleAgencyCode = "B",
			ComponentMaterialDescription = "u",
		};

		var actual = Map.MapComposite<C824_ComponentMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
