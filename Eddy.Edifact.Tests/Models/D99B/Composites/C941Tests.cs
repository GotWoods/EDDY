using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C941Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:d:R:0";

		var expected = new C941_Relationship()
		{
			RelationshipDescriptionCode = "K",
			CodeListIdentificationCode = "d",
			CodeListResponsibleAgencyCode = "R",
			RelationshipDescription = "0",
		};

		var actual = Map.MapComposite<C941_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
