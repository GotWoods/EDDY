using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C941Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:F:R:C";

		var expected = new C941_Relationship()
		{
			RelationshipDescriptionCode = "H",
			CodeListIdentificationCode = "F",
			CodeListResponsibleAgencyCode = "R",
			RelationshipDescription = "C",
		};

		var actual = Map.MapComposite<C941_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
