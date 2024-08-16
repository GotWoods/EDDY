using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C503Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:6:8:F";

		var expected = new C503_DocumentMessageDetails()
		{
			DocumentMessageNumber = "M",
			DocumentMessageStatusCoded = "6",
			DocumentMessageSource = "8",
			LanguageCoded = "F",
		};

		var actual = Map.MapComposite<C503_DocumentMessageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
