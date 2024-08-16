using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C822Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:g:I:Q";

		var expected = new C822_DamageArea()
		{
			DamageAreaIdentification = "L",
			CodeListQualifier = "g",
			CodeListResponsibleAgencyCoded = "I",
			DamageArea = "Q",
		};

		var actual = Map.MapComposite<C822_DamageArea>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
