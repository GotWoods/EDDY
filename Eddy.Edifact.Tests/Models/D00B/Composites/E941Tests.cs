using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E941Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:o:Z:C";

		var expected = new E941_Relationship()
		{
			RelationshipDescriptionCode = "s",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "Z",
			RelationshipDescription = "C",
		};

		var actual = Map.MapComposite<E941_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
