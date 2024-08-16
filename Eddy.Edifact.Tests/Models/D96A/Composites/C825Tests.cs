using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C825Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:3:5:t";

		var expected = new C825_DamageSeverity()
		{
			DamageSeverityCoded = "g",
			CodeListQualifier = "3",
			CodeListResponsibleAgencyCoded = "5",
			DamageSeverity = "t",
		};

		var actual = Map.MapComposite<C825_DamageSeverity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
