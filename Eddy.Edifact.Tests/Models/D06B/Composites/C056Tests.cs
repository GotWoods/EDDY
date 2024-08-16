using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06B;
using Eddy.Edifact.Models.D06B.Composites;

namespace Eddy.Edifact.Tests.Models.D06B.Composites;

public class C056Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:f";

		var expected = new C056_ContactDetails()
		{
			ContactIdentifier = "C",
			ContactName = "f",
		};

		var actual = Map.MapComposite<C056_ContactDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
