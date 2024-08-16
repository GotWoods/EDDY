using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C585Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Y:t:m:6";

		var expected = new C585_PriorityDetails()
		{
			PriorityCoded = "Y",
			CodeListIdentificationCode = "t",
			CodeListResponsibleAgencyCode = "m",
			Priority = "6",
		};

		var actual = Map.MapComposite<C585_PriorityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
