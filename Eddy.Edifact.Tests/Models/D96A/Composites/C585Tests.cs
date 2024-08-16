using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C585Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:8:l:9";

		var expected = new C585_PriorityDetails()
		{
			PriorityCoded = "j",
			CodeListQualifier = "8",
			CodeListResponsibleAgencyCoded = "l",
			Priority = "9",
		};

		var actual = Map.MapComposite<C585_PriorityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
