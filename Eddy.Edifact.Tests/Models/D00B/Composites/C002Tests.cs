using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:j:F:g";

		var expected = new C002_DocumentMessageName()
		{
			DocumentNameCode = "U",
			CodeListIdentificationCode = "j",
			CodeListResponsibleAgencyCode = "F",
			DocumentName = "g",
		};

		var actual = Map.MapComposite<C002_DocumentMessageName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
