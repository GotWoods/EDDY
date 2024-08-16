using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C288Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:B:p:d";

		var expected = new C288_ProductGroup()
		{
			ProductGroupNameCode = "B",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "p",
			ProductGroupName = "d",
		};

		var actual = Map.MapComposite<C288_ProductGroup>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
