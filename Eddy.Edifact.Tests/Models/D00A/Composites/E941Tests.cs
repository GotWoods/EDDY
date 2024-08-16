using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E941Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "c:1:H:f";

		var expected = new E941_Relationship()
		{
			RelationshipDescriptionCode = "c",
			CodeListIdentificationCode = "1",
			CodeListResponsibleAgencyCode = "H",
			RelationshipDescription = "f",
		};

		var actual = Map.MapComposite<E941_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
