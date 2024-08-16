using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C531Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Q:S:X";

		var expected = new C531_PackagingDetails()
		{
			PackagingLevelCode = "Q",
			PackagingRelatedDescriptionCode = "S",
			PackagingTermsAndConditionsCode = "X",
		};

		var actual = Map.MapComposite<C531_PackagingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
