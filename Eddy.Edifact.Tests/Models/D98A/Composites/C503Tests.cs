using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class C503Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:0:m:N";

		var expected = new C503_DocumentMessageDetails()
		{
			DocumentMessageNumber = "i",
			DocumentMessageStatusCoded = "0",
			DocumentMessageSource = "m",
			LanguageCoded = "N",
		};

		var actual = Map.MapComposite<C503_DocumentMessageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
