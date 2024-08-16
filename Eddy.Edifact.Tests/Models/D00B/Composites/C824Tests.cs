using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C824Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:4:b:j";

		var expected = new C824_ComponentMaterial()
		{
			ComponentMaterialDescriptionCode = "P",
			CodeListIdentificationCode = "4",
			CodeListResponsibleAgencyCode = "b",
			ComponentMaterialDescription = "j",
		};

		var actual = Map.MapComposite<C824_ComponentMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
