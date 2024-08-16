using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C503Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "O:E:V:H:v:p";

		var expected = new C503_DocumentMessageDetails()
		{
			DocumentMessageNumber = "O",
			DocumentMessageStatusCoded = "E",
			DocumentMessageSource = "V",
			LanguageCoded = "H",
			Version = "v",
			RevisionNumber = "p",
		};

		var actual = Map.MapComposite<C503_DocumentMessageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
