using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C824Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:a:P:b";

		var expected = new C824_ComponentMaterial()
		{
			ComponentMaterialCoded = "m",
			CodeListQualifier = "a",
			CodeListResponsibleAgencyCoded = "P",
			ComponentMaterial = "b",
		};

		var actual = Map.MapComposite<C824_ComponentMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
