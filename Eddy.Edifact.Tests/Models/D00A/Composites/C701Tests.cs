using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C701Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:J:b";

		var expected = new C701_ErrorPointDetails()
		{
			MessageSectionCode = "G",
			MessageItemIdentifier = "J",
			MessageSubItemIdentifier = "b",
		};

		var actual = Map.MapComposite<C701_ErrorPointDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
