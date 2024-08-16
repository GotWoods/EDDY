using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C941Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:e:N:G";

		var expected = new C941_Relationship()
		{
			RelationshipCoded = "D",
			CodeListQualifier = "e",
			CodeListResponsibleAgencyCoded = "N",
			Relationship = "G",
		};

		var actual = Map.MapComposite<C941_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
