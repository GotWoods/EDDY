using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C701Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:j:D";

		var expected = new C701_ErrorPointDetails()
		{
			MessageSectionCoded = "M",
			MessageItemNumber = "j",
			MessageSubItemNumber = "D",
		};

		var actual = Map.MapComposite<C701_ErrorPointDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
