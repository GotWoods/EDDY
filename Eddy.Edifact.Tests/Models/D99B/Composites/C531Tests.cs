using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C531Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:P:f";

		var expected = new C531_PackagingDetails()
		{
			PackagingLevelCoded = "r",
			PackagingRelatedDescriptionCode = "P",
			PackagingTermsAndConditionsCoded = "f",
		};

		var actual = Map.MapComposite<C531_PackagingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
