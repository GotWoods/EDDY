using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C531Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "z:Z:5";

		var expected = new C531_PackagingDetails()
		{
			PackagingLevelCoded = "z",
			PackagingRelatedInformationCoded = "Z",
			PackagingTermsAndConditionsCoded = "5",
		};

		var actual = Map.MapComposite<C531_PackagingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
