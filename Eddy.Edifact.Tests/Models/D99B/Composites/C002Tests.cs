using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:d:G:H";

		var expected = new C002_DocumentMessageName()
		{
			DocumentNameCode = "2",
			CodeListIdentificationCode = "d",
			CodeListResponsibleAgencyCode = "G",
			DocumentName = "H",
		};

		var actual = Map.MapComposite<C002_DocumentMessageName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
