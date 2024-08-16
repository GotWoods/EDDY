using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C288Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:N:m:v";

		var expected = new C288_ProductGroup()
		{
			ProductGroupCoded = "D",
			CodeListQualifier = "N",
			CodeListResponsibleAgencyCoded = "m",
			ProductGroup = "v",
		};

		var actual = Map.MapComposite<C288_ProductGroup>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
