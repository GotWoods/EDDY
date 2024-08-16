using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C288Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:n:R:p";

		var expected = new C288_ProductGroup()
		{
			ProductGroupNameCode = "6",
			CodeListIdentificationCode = "n",
			CodeListResponsibleAgencyCode = "R",
			ProductGroupName = "p",
		};

		var actual = Map.MapComposite<C288_ProductGroup>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
